
using AutoMapper;
using Structure.Domain.Resource.Dto;
using Structure.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application.Resources
{
    public class ResourceAppService : IResourceAppService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _objectMapper;

        public ResourceAppService(IResourceRepository resourceRepository, IMapper objectMapper)
        {
            _resourceRepository = resourceRepository;
            _objectMapper = objectMapper;
        }
        public virtual async Task<ResourceDto> CreateAsync(ResourceCreateDto input)
        {
            var resource = _objectMapper.Map<ResourceCreateDto, Resource>(input);
            //resource.TenantId = CurrentTenant.Id;
            resource = await _resourceRepository.InsertAsync(resource, autoSave: true);
            Console.WriteLine(resource.ResourceId);

            return _objectMapper.Map<Resource, ResourceDto>(resource);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _resourceRepository.DeleteAsync(id);
        }

        public virtual async Task<ResourceDto> GetAsync(Guid id)
        {
            return _objectMapper.Map<Resource, ResourceDto>(await _resourceRepository.GetAsync(id));
        }

        public virtual async Task<List<ResourceDto>> GetListAsync(GetResourcesInput input)
        {
            var items = await _resourceRepository.GetListAsync(input.FilterText, input.DoctorName, input.TextCss, input.BackgroundCss, input.GroupIdMin, 
                input.GroupIdMax, input.IsGroup, input.Name, input.ResourceIdMin, input.ResourceIdMax);

            return _objectMapper.Map<List<Resource>, List<ResourceDto>>(items);


        }

        public virtual async Task<ResourceDto> UpdateAsync(Guid id, ResourceUpdateDto input)
        {
            var resource = await _resourceRepository.GetAsync(id);
            _objectMapper.Map(input, resource);
            resource = await _resourceRepository.UpdateAsync(resource);
            return _objectMapper.Map<Resource, ResourceDto>(resource);
        }
    }
}
