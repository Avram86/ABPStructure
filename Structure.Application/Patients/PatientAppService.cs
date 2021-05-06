
using AutoMapper;
using Structure.Domain.Patients;
using Structure.Domain.Patients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Patients
{
    public class PatientAppService : IPatientAppService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _objectMapper;

        public PatientAppService(IPatientRepository patientRepository, IMapper objectMapper)
        {
            _patientRepository = patientRepository;
            _objectMapper = objectMapper;
        }
        public virtual async Task<PatientDto> CreateAsync(PatientCreateDto input)
        {
            var patient = _objectMapper.Map<PatientCreateDto, Patient>(input);
            //patient.TenantId = CurrentTenant.Id;
            patient = await _patientRepository.InsertAsync(patient, autoSave: true);
            return _objectMapper.Map<Patient, PatientDto>(patient);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _patientRepository.DeleteAsync(id);
        }

        public virtual async Task<PatientDto> GetAsync(Guid id)
        {
            return _objectMapper.Map<Patient, PatientDto>(await _patientRepository.GetAsync(id));
        } 

        public virtual async Task<List<PatientDto>> GetListAsync(GetPatientsInput input)
        {
            var items = await _patientRepository.GetListAsync(input.FilterText, input.UnitateSanitara, input.NrFisaMin, input.NrFisaMax, input.NrVechiFisaArhivaMin, input.NrVechiFisaArhivaMax, input.DataCreariiFiseiMin, input.DataCreariiFiseiMax, input.CNP, input.Nume, input.Prenume, input.DataNasteriiMin, input.DataNasteriiMax, input.Decedat, input.StareCivila, input.SexulPacientului,
                input.Telefon, input.Localitate, input.Strada, input.NrStraziiMin, input.NrStraziiMax, input.Ocupatie, input.LocMunca, input.SchimbariDomiciliu, input.SchimbariLocMunca, 
                input.AntecedenteHeredo_Colaterale, input.AntecedentePersonale, input.AntecdenteConditiiMunca, input.Grupe);

            return _objectMapper.Map<List<Patient>, List<PatientDto>>(items);

        }

        public async Task<Dictionary<string, int>> GetPatientsWithMaritalStatus()
        {
            var Casatorit = await _patientRepository.GetCountAsync(stareCivila: StareCivila.Casatorit);
            var Necasatorit = await _patientRepository.GetCountAsync(stareCivila: StareCivila.Necasatorit);
            var Divortat = await _patientRepository.GetCountAsync(stareCivila: StareCivila.Divortat);
            var Vaduv = await _patientRepository.GetCountAsync(stareCivila: StareCivila.Vaduv);

            var result = new Dictionary<string, int>();
            result.Add(Enum.GetName(StareCivila.Casatorit), (int)Casatorit);
            result.Add(Enum.GetName(StareCivila.Necasatorit), (int)Necasatorit);
            result.Add(Enum.GetName(StareCivila.Divortat), (int)Divortat);
            result.Add(Enum.GetName(StareCivila.Vaduv), (int)Vaduv);

            return result;
        }

        public async  Task<int> MaxNrFisa()
        {
            int nrFiseLista;

            var pacienti = await _patientRepository.GetListAsync();
            if (pacienti.Count == 0)
            {
                nrFiseLista = 1;
            }
            else
            {
                nrFiseLista = pacienti.Select(p => p.NrFisa).Max();
            }
            
            return nrFiseLista;
        }

        public async Task<bool> PatientExists(Guid id)
        {
            var pacienti = await _patientRepository.GetListAsync();
            var idList = pacienti.Select(p => p.Id).ToList();
            var result = false;

            foreach (var item in idList)
            {
                if (item == id) result = true;
            }
            return result;
        }

        public virtual async Task<PatientDto> UpdateAsync(Guid id, PatientUpdateDto input)
        {
            var patient = await _patientRepository.GetAsync(id);
            _objectMapper.Map(input, patient);
            patient = await _patientRepository.UpdateAsync(patient);
            return _objectMapper.Map<Patient, PatientDto>(patient);
        }
    }
}
