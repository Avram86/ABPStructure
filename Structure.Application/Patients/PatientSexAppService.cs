using Microsoft.Extensions.Logging;
using Structure.Domain.Patients;
using Structure.Domain.Patients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application.Patients
{
    public class PatientSexAppService : IPatientSexAppService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientSexAppService> _Log;

        public PatientSexAppService(IPatientRepository patientRepository, ILogger<PatientSexAppService> Log)
        {
            _patientRepository = patientRepository;
            _Log = Log;
        }
        public async Task<Dictionary<string, int>> GetMaleFemalePacients()
        {
            var masculin = await _patientRepository.GetCountAsync(sexulPacientului: Sex.Masculin);
            var feminin = await _patientRepository.GetCountAsync(sexulPacientului: Sex.Masculin);

            var result = new Dictionary<string, int>();

            result.Add("masculin", (int)masculin);
            result.Add("feminin", (int)feminin);
            _Log.LogWarning($"masculin: {(int)masculin}; feminin : {(int)feminin}");

            return result;
        }
    }
}
