
using AutoMapper;
using Structure.Domain.Patients;
using Structure.Domain.Patients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application.Patients
{
    public class PatientIdsAppService : IPatientIdsAppService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _objectMapper;

        public PatientIdsAppService(IPatientRepository patientRepository, IMapper objectMapper)
        {
            _patientRepository = patientRepository;
            _objectMapper = objectMapper;
        }
        public async Task<List<Guid>> GetPacientsIds()
        {
            var patients = await _patientRepository.GetGuidIds();

            return patients;
        }
    }
}
