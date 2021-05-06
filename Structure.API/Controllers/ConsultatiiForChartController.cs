using Microsoft.AspNetCore.Mvc;
using Structure.Domain.Consultatii.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API.Controllers
{
    [ApiController]
    [Route("api/app/consultatiiForChart")]
    public class ConsultatiiForChartController : Controller, IConsultatiiforchartAppService
    {
        private readonly IConsultatiiforchartAppService _consultatiiforchartAppService;

        public ConsultatiiForChartController(IConsultatiiforchartAppService consultatiiforchartAppService)
        {
            _consultatiiforchartAppService = consultatiiforchartAppService;
        }
        [HttpGet(Name = "GetConsultatiiForChart")]
        public async Task<Dictionary<string, Dictionary<string, int>>> GetAllConsultatii()
        {
            //List<string> ResourceNamesList = new List<string>();
            //List<int> nrConsultatiiAleDr = new List<int>();

            //List<Dictionary<string, int>> innerDict = new List<Dictionary<string, int>>();
            //Dictionary<string, Dictionary<string, int>> outerDict = new Dictionary<string, Dictionary<string, int>>();

            //List<string> datesList = new List<string>();

            //List<string> userList = GetResourceNameList();


            //var pacientsids = (IEnumerable<int>)_patientIdsAppService.GetPacientsIds();

            //foreach (var user in userList)
            //{
            //    ResourceNamesList.Add(user);
            //    nrConsultatiiAleDr.Add(0);
            //}

            //List<ConsultatieDto> result = new List<ConsultatieDto>();

            //foreach (var id in pacientsids)
            //{
            //    var x = GetConsultatiiForChart(id);
            //    foreach (var consult in x)
            //    {
            //        result.Add(consult);
            //    }
            //}

            ////ordered appointments
            //result = result.OrderBy(r => r.Data).ToList();

            //for (int k = 0; k < result.Count() - 1; k++)
            //{
            //    for (int j = 0; j < ResourceNamesList.Count; j++)
            //    {
            //        if (result[k].ResourceName.Contains(ResourceNamesList[j].Substring(0, ResourceNamesList[j].IndexOf(' ')))
            //            && result[k].ResourceName.Contains(ResourceNamesList[j].Substring(ResourceNamesList[j].IndexOf(' ') + 1)))
            //        {
            //            nrConsultatiiAleDr[j]++;
            //        }
            //    }


            //    //if date changes
            //    if (result[k].Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            //        != result[k + 1].Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
            //    {
            //        for (int i = 0; i < ResourceNamesList.Count; i++)
            //        {
            //            //adaugam la lista atatea dictionare goale pt a putea folosi indexul lor
            //            innerDict.Add(new Dictionary<string, int>());
            //        }

            //        //we write the counted appointments into the dictionary
            //        for (int i = 0; i < ResourceNamesList.Count; i++)
            //        {
            //            //pe urma adaugam valori in dictionare
            //            innerDict[i].Add(result[k].Data.ToShortDateString(), nrConsultatiiAleDr[i]);
            //        }

            //        //add a new date to the date List
            //        datesList.Add(result[k].Data.ToShortDateString());

            //        //set count appointments/Resource to 0
            //        nrConsultatiiAleDr = new List<int>();

            //        for (int i = 0; i < ResourceNamesList.Count; i++)
            //        {
            //            nrConsultatiiAleDr.Add(0);
            //        }

            //    }
            //}

            ////add last date to list
            //if (result[result.Count - 1].Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            //    != result[result.Count - 2].Data.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
            //{
            //    for (int i = 0; i < ResourceNamesList.Count; i++)
            //    {
            //        //pe urma adaugam valori in dictionare
            //        innerDict[i].Add(result[result.Count - 1].Data.ToShortDateString(), nrConsultatiiAleDr[i]);
            //    }
            //    datesList.Add(result[result.Count - 1].Data.ToShortDateString());
            //}

            //for (int i = 0; i < ResourceNamesList.Count; i++)
            //{
            //    outerDict.Add(ResourceNamesList[i], innerDict[i]);
            //}

            return await _consultatiiforchartAppService.GetAllConsultatii();

        }

        //[HttpGet(Name ="GetConsultatiiForACertainPatient ")]
        //[Route("api/app/consultatiiForAPatient/{pacientId}")]
        //error: NotSupportedException: Conflicting method/path combination "GET api/app/patients" for actions - ABP.PacientiPsihiatrie.Controllers.Consultatii.ConsultatiiForChartController.GetConsultatii(ABP.PacientiPsihiatrie.HttpApi),
        //ABP.PacientiPsihiatrie.Controllers.Consultatii.ConsultatiiForChartController.GetConsultatiiForChart(ABP.PacientiPsihiatrie.HttpApi),

        [NonAction]
        public async Task<List<ConsultatieDto>> GetConsultatiiForChart(Guid pacientId)
        {
            return await _consultatiiforchartAppService.GetConsultatiiForChart(pacientId);
        }

    }
}
