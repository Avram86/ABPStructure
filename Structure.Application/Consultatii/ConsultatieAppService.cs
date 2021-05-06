
//using Structure.Application.ObjectMapper;
using AutoMapper;
using Structure.Domain.Consultatii;
using Structure.Domain.Consultatii.Dto;
using Structure.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii
{
    public class ConsultatieAppService : IConsultatieAppService
    {
        private readonly IConsultatieRepository _consultatieRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _objectMapper;

        public ConsultatieAppService(IConsultatieRepository consultatieRepository, IPatientRepository patientRepository, IMapper objectMapper)
        {
            _consultatieRepository = consultatieRepository;
            _patientRepository = patientRepository;
            _objectMapper = objectMapper;
        }
        public virtual async Task<ConsultatieDto> CreateAsync(ConsultatieCreateDto input)
        {
            var consultatie = new Consultatie();
            _objectMapper.Map(input,consultatie);
                //= _objectMapper.Map<ConsultatieCreateDto, Consultatie>(input);
            //consultatie.TenantId = CurrentTenant.Id;
            consultatie = await _consultatieRepository.InsertAsync(consultatie, autoSave: true);
            return _objectMapper.Map<Consultatie, ConsultatieDto>(consultatie);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _consultatieRepository.DeleteAsync(id);
        }

        public virtual async Task<ConsultatieDto> GetAsync(Guid id)
        {
            return _objectMapper.Map<Consultatie, ConsultatieDto>(await _consultatieRepository.GetAsync(id));
        }

        public virtual async Task<List<ConsultatieWithNavigationPropertiesDto>> GetListAsync(GetConsultatiiInput input)
        {
            var items=await _consultatieRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.DataMin, input.DataMax, input.LoculConsultatiei, 
                input.Simptome, input.Diagnostic, input.Cod, input.Prescriptii, input.ZileConcediuRecomandateMin, input.ZileConcediuRecomandateMax, input.PatientId, 
                input.ResourceId, input.IsConsultPsihologic, input.DetaliiPsiholog);

            return _objectMapper.Map<List<ConsultatieWithNavigationProperties>, List<ConsultatieWithNavigationPropertiesDto>>(items);
            
        }

        public virtual async Task<ConsultatieWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _objectMapper.Map<ConsultatieWithNavigationProperties, ConsultatieWithNavigationPropertiesDto>
                (await _consultatieRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ConsultatieDto> UpdateAsync(Guid id, ConsultatieUpdateDto input)
        {
            var consultatie = await _consultatieRepository.GetAsync(id);
            _objectMapper.Map(input, consultatie);
            consultatie = await _consultatieRepository.UpdateAsync(consultatie);
            return _objectMapper.Map<Consultatie, ConsultatieDto>(consultatie);
        }
    }
}
