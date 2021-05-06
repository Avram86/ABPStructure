using Structure.Application.Services;
using Structure.Domain.Resource.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Resources
{
   public  interface IResourceAppService:IApplicationService
    {
        Task<List<ResourceDto>> GetListAsync(GetResourcesInput input);

        Task<ResourceDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResourceDto> CreateAsync(ResourceCreateDto input);

        Task<ResourceDto> UpdateAsync(Guid id, ResourceUpdateDto input);
    }
}
