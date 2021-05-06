using Microsoft.AspNetCore.Mvc;
using Structure.Domain.Patients;
using Structure.Domain.Patients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API.Controllers
{
    [ApiController]
    [Route("api/app/patientsMaleFemale")]
    public class PatientsMaleFemaleController:Controller, IPatientSexAppService
    {
        private readonly IPatientSexAppService _patientSexAppService;

        public PatientsMaleFemaleController(IPatientSexAppService patientSexAppService)
        {
            _patientSexAppService = patientSexAppService;
        }

        [HttpGet]
        public Task<Dictionary<string, int>> GetMaleFemalePacients()
        {
            return _patientSexAppService.GetMaleFemalePacients();
        }
    }
}
