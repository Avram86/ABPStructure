using Microsoft.AspNetCore.Mvc;
using Structure.Domain.Resource.Dto;
using Structure.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API.Controllers
{
    [ApiController]
    [Route("api/app/resources")]
    public class ResourceController : Controller, IResourceAppService
    {
        private readonly IResourceAppService _resourceAppService;

        public ResourceController(IResourceAppService resourceAppService)
        {
            _resourceAppService = resourceAppService;
        }
        [HttpPost]
        public async Task<ResourceDto> CreateAsync(ResourceCreateDto input)
        {
            var created = _resourceAppService.CreateAsync(input);
            return await created;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _resourceAppService.DeleteAsync(id);
        }


        [HttpGet]
        [Route("{id}")]
        public Task<ResourceDto> GetAsync(Guid id)
        {
            return _resourceAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<List<ResourceDto>> GetListAsync([FromQuery]GetResourcesInput input)
        {
            return await _resourceAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ResourceDto> UpdateAsync(Guid id, ResourceUpdateDto input)
        {
            return _resourceAppService.UpdateAsync(id, input);
        }
    }
}
