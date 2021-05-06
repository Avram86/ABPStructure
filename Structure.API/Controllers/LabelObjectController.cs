using Microsoft.AspNetCore.Mvc;
using Structure.Domain.LabelObjects;
using Structure.Domain.LabelObjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API.Controllers
{
    [ApiController]
    [Route("api/app/label-objects")]
    public class LabelObjectController : Controller, ILabelObjectAppService
    {
        private readonly ILabelObjectAppService _appService;

        public LabelObjectController(ILabelObjectAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<LabelObjectDto> CreateAsync(LabelObjectCreateDto input)
        {
            var created = await _appService.CreateAsync(input);
            return created;
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _appService.DeleteAsync(id);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<LabelObjectDto> GetAsync(Guid id)
        {
            return await _appService.GetAsync(id);   
        }

        [HttpGet]
        public async  Task<List<LabelObjectDto>> GetListAsync([FromQuery] GetLabelObjectsInput input)
        {
            return await _appService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<LabelObjectDto> UpdateAsync(Guid id, LabelObjectUpdateDto input)
        {
            return _appService.UpdateAsync(id, input);
        }
    }
}
