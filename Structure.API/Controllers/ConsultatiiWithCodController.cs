using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Structure.Domain.Consultatii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API.Controllers
{
    [ApiController]
    [Route("api/app/patients/{pacientId}/consultatiiCuCod")]
    public class ConsultatiiWithCodController : Controller, IConsultatiWithCodAppService
    {
        private readonly IConsultatiWithCodAppService _consultatiWithCodAppService;
        private readonly ILogger<ConsultatiiWithCodController> _Log;

        public ConsultatiiWithCodController(IConsultatiWithCodAppService consultatiWithCodAppService,
            ILogger<ConsultatiiWithCodController> Log)
        {
            _consultatiWithCodAppService = consultatiWithCodAppService;
            _Log = Log;
        }
        [HttpGet]
        public async virtual Task<Dictionary<string, int>> GetConsultatiiWithCod(Guid pacientId)
        {
            var codeDictionary = await _consultatiWithCodAppService.GetConsultatiiWithCod(pacientId);
            foreach (var key in codeDictionary.Keys)
            {
                _Log.LogInformation($"Din CONSULTATIIWITHCOD APP SERVICE {key}: {codeDictionary[key]}");
            }
            return codeDictionary;
        }

    }
}
