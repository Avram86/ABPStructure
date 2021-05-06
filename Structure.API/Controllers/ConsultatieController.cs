using Microsoft.AspNetCore.Mvc;
using Structure.Domain.Consultatii;
using Structure.Domain.Consultatii.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API.Controllers
{
    [ApiController]
    [Route("api/app/consultaties")]
    public class ConsultatieController : Controller, IConsultatieAppService
    {
        private readonly IConsultatieAppService _consultatieAppService;

        public ConsultatieController(IConsultatieAppService consultatieAppService)
        {
            _consultatieAppService = consultatieAppService;
        }


        [HttpPost]
        public Task<ConsultatieDto> CreateAsync(ConsultatieCreateDto input)
        {
            return _consultatieAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _consultatieAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ConsultatieDto> GetAsync(Guid id)
        {
            return _consultatieAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<List<ConsultatieWithNavigationPropertiesDto>> GetListAsync([FromQuery]GetConsultatiiInput input)
        {
            return _consultatieAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<ConsultatieWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _consultatieAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ConsultatieDto> UpdateAsync(Guid id, ConsultatieUpdateDto input)
        {
            return _consultatieAppService.UpdateAsync(id, input);
        }
    }
}
