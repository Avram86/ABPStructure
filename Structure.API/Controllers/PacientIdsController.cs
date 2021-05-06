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
    [Route("api/app/patientsIds")]
    public class PacientIdsController:Controller, IPatientIdsAppService
    {
        private readonly IPatientIdsAppService _patientIdsAppService;

        public PacientIdsController(IPatientIdsAppService patientIdsAppService)
        {
            _patientIdsAppService = patientIdsAppService;
        }

        [HttpGet]
        public async Task<List<Guid>> GetPacientsIds()
        {
            return await _patientIdsAppService.GetPacientsIds();
        }
    }
}
