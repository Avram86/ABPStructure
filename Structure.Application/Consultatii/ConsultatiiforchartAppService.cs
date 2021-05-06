
using AutoMapper;
using Structure.Domain.Consultatii;
using Structure.Domain.Consultatii.Dto;
using Structure.Domain.Resource;
using Structure.Domain.Resource.Dto;
using Structure.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application.Consultatii
{
    public class ConsultatiiforchartAppService : IConsultatiiforchartAppService
    {
        private readonly IConsultatieRepository _consultatieRepository;
        private readonly IResourceAppService _resourceAppService;
        private readonly IMapper _objectMapper;

        public ConsultatiiforchartAppService(IConsultatieRepository consultatieRepository, IResourceAppService resourceAppService,
            IMapper objectMapper)
        {
            _consultatieRepository = consultatieRepository;
            _resourceAppService = resourceAppService;
            _objectMapper = objectMapper;
        }
        public async Task<Dictionary<string, Dictionary<string, int>>> GetAllConsultatii()
        {
            List<string> ResourceNamesList = new List<string>();
            List<int> nrConsultatiiAleDr = new List<int>();

            List<Dictionary<string, int>> innerDict = new List<Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> outerDict = new Dictionary<string, Dictionary<string, int>>();

            List<string> datesList = new List<string>();

            List<Guid> doctorGuidList = new List<Guid>();
            List<string> userList = new List<string>();
            var Resources = await _resourceAppService.GetListAsync(new GetResourcesInput());
            //beacouse the Dto does not contain an ID property
            var ResourcesWIthId = _objectMapper.Map<List<ResourceDto>, List<Resource>>(Resources);

            //luam toata lista de doctori
            foreach (var Resource in ResourcesWIthId)
            {
                userList.Add(Resource.DoctorName);
                doctorGuidList.Add(Resource.Id);
            }


            //var pacientsids = await _patientIdsAppService.GetPacientsIds();

            foreach (var user in userList)
            {
                //????in loc de ResourceNamesList putem folosi usreList
                ResourceNamesList.Add(user);
                nrConsultatiiAleDr.Add(0);
            }

            //recuperam toate consultatiile din DB (deja ordonate dupa data)
            var result =_objectMapper.Map<List<ConsultatieWithNavigationProperties>, List<ConsultatieWithNavigationPropertiesDto>>
                (await _consultatieRepository.GetOrderedWithNavigationPropertiesAsync());

            //pt fiecare consultatie
            for (int k = 0; k < result.Count - 1; k++)
            {
                //pt fiecare doctor din lista
                for (int j = 0; j < ResourceNamesList.Count - 1; j++)
                {
                    //daca consultatia contine numele doctorului
                    if (result[k].Resource.DoctorName.Contains(ResourceNamesList[j].Substring(0, ResourceNamesList[j].IndexOf(' ')))
                        && result[k].Resource.DoctorName.Contains(ResourceNamesList[j].Substring(ResourceNamesList[j].IndexOf(' ') + 1)))
                    {
                        //atunci crestem cu 1 nr de consultatii ale doctorului
                        nrConsultatiiAleDr[j]++;
                    }
                    Console.WriteLine(nrConsultatiiAleDr[j]);
                }
                Console.WriteLine(result[k].Resource.DoctorName);


                //if date changes
                //daca se schimba data consultatiilor(ele fiind aranjate dupa data)
                if (result[k].Consultatie.Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                    != result[k + 1].Consultatie.Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
                {
                    for (int i = 0; i < ResourceNamesList.Count; i++)
                    {
                        //pt noua data
                        //adaugam la lista atatea dictionare goale pt a putea folosi indexul lor
                        innerDict.Add(new Dictionary<string, int>());
                    }

                    //we write the counted appointments into the dictionary
                    for (int i = 0; i < ResourceNamesList.Count; i++)
                    {
                        //pe urma adaugam valori in dictionare
                        innerDict[i].Add(result[k].Consultatie.Data.ToShortDateString(), nrConsultatiiAleDr[i]);
                    }

                    //add a new date to the date List
                    datesList.Add(result[k].Consultatie.Data.ToShortDateString());

                    //set count appointments/Resource to 0
                    nrConsultatiiAleDr = new List<int>();

                    for (int i = 0; i < ResourceNamesList.Count; i++)
                    {
                        nrConsultatiiAleDr.Add(0);
                    }

                }

            }

            Debug.WriteLine(result[result.Count - 2].Consultatie.Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            Debug.WriteLine(result[result.Count - 1].Consultatie.Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));

            //add last date to list
            //ultima data: result[result.Count - 1].Consultatie.Data.
            if (result[result.Count - 1].Consultatie.Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                != result[result.Count - 2].Consultatie.Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
            {
                //set count appointments/Resource to 0
                nrConsultatiiAleDr = new List<int>();
                int g = 0;
                foreach (var i in ResourceNamesList)
                {
                    //pornim numaratoarea consultatiilor de la 0
                    nrConsultatiiAleDr.Add(0);

                    //daca consultatia contine numele doctorului
                    //ATENTIE eroare sau graficul ignora ultima data
                    //daca testam cu un doctor ce are un singur nume
                    if (result[result.Count - 1].Resource.DoctorName.Contains(i.Substring(0, i.IndexOf(' ')))
                        && result[result.Count - 1].Resource.DoctorName.Contains(i.Substring(i.IndexOf(' ') + 1)))
                    {
                        //atunci crestem cu 1 nr de consultatii ale doctorului
                        nrConsultatiiAleDr[g]++;
                    }

                    g++;
                }


                for (int i = 0; i < ResourceNamesList.Count; i++)
                {
                    //pt fiecare doctor
                    //pe urma adaugam valori in dictionare
                    innerDict[i].Add(result[result.Count - 1].Consultatie.Data.ToShortDateString(), nrConsultatiiAleDr[i]);
                }

                //adauga data in lista de date
                datesList.Add(result[result.Count - 1].Consultatie.Data.ToShortDateString());
            }


            for (int i = 0; i < ResourceNamesList.Count; i++)
            {
                outerDict.Add(ResourceNamesList[i], innerDict[i]);
            }

            return outerDict;
        }

        public Task<List<ConsultatieDto>> GetConsultatiiForChart(Guid pacientId)
        {
            throw new NotImplementedException();
        }
    }
}
