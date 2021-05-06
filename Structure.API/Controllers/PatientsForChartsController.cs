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
    [Route("api/app/patientsForCharts")]
    public class PatientsForChartsController:Controller, IPatientsForChartsAppService
    {
        private readonly IPatientsForChartsAppService _patientForChartAppService;

        public PatientsForChartsController(IPatientsForChartsAppService patientForChartAppService)
        {
            _patientForChartAppService = patientForChartAppService;
        }
        [HttpGet]
        public virtual async Task<List<int>> GetPatientsForCharts()
        {
            return await _patientForChartAppService.GetPatientsForCharts();
        }
    }
}
