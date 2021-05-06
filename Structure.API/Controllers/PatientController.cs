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
    [Route("api/app/patients")]
    public class PatientController : Controller, IPatientAppService
    {
        private readonly IPatientAppService _patientAppService;

        public PatientController(IPatientAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }

        [HttpPost]
        public async Task<PatientDto> CreateAsync(PatientCreateDto input)
        {
            int nrMaxFisa = await _patientAppService.MaxNrFisa();
            input.NrFisa = nrMaxFisa + 1;
            return await _patientAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _patientAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<PatientDto> GetAsync(Guid id)
        {
            return _patientAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<List<PatientDto>> GetListAsync([FromQuery]GetPatientsInput input)
        {
            return _patientAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("/maritalStatus")]
        public async Task<Dictionary<string, int>> GetPatientsWithMaritalStatus()
        {
            return await _patientAppService.GetPatientsWithMaritalStatus();
        }

        [NonAction]
        public Task<int> MaxNrFisa()
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public Task<bool> PatientExists(Guid id)
        {
            throw new NotImplementedException();
        }


        [HttpPut]
        [Route("{id}")]
        public Task<PatientDto> UpdateAsync(Guid id, PatientUpdateDto input)
        {
            return _patientAppService.UpdateAsync(id, input);
        }
    }
}
