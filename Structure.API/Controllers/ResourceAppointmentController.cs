using Microsoft.AspNetCore.Mvc;
using Structure.Domain.ResourceAppointments;
using Structure.Domain.ResourceAppointments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API.Controllers
{
    [ApiController]
    [Route("api/app/resource-appointments")]
    public class ResourceAppointmentController : Controller, IResourceAppointmentAppService
    {
        private readonly IResourceAppointmentAppService _resourceAppointmentAppService;

        public ResourceAppointmentController(IResourceAppointmentAppService resourceAppointmentAppService)
        {
            _resourceAppointmentAppService = resourceAppointmentAppService;
        }
        [HttpPost]
        public async virtual Task<ResourceAppointmentDto> CreateAsync(ResourceAppointmentCreateDto input)
        {
            var created= await _resourceAppointmentAppService.CreateAsync(input);
            return created;
        }

        [HttpDelete]
        [Route("{id}")]
        public  Task DeleteAsync(Guid id)
        {
            return _resourceAppointmentAppService.DeleteAsync(id);
        }

        [HttpDelete]
        [Route("int/{id}")]
        public Task DeleteIntAsync(int id)
        {
            return _resourceAppointmentAppService.DeleteIntAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResourceAppointmentDto> GetAsync(Guid id)
        {
            return await _resourceAppointmentAppService.GetAsync(id);
        }


        [HttpGet]
        [Route("int/{id}")]
        public async Task<ResourceAppointmentDto> GetIntAsync(int id)
        {
            return await _resourceAppointmentAppService.GetIntAsync(id);
        }

        [HttpGet]
        public Task<List<ResourceAppointmentWithNavigationPropertiesDto>> GetListAsync([FromQuery] GetResourceAppointmentsInput input)
        {
            return _resourceAppointmentAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public async Task<ResourceAppointmentWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return await _resourceAppointmentAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ResourceAppointmentDto> UpdateAsync(Guid id, ResourceAppointmentUpdateDto input)
        {
            return await _resourceAppointmentAppService.UpdateAsync(id, input);
        }
    }
}
