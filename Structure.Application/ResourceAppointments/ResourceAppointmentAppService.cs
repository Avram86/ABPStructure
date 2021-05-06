

using AutoMapper;
using Structure.Domain.Resource.Dto;
using Structure.Domain.ResourceAppointments;
using Structure.Domain.ResourceAppointments.Dto;
using Structure.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application.ResourceAppointments
{
    public class ResourceAppointmentAppService : IResourceAppointmentAppService
    {
        private readonly IResourceAppointmentRepository _resourceAppointmentRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _objectMapper;

        public ResourceAppointmentAppService(IResourceAppointmentRepository resourceAppointmentRepository, IResourceRepository resourceRepository,
            IMapper objectMapper)
        {
            _resourceAppointmentRepository = resourceAppointmentRepository;
            _resourceRepository = resourceRepository;
            _objectMapper = objectMapper;
        }
        public virtual async Task<ResourceAppointmentDto> CreateAsync(ResourceAppointmentCreateDto input)
        {
            var resourceAppointment = _objectMapper.Map<ResourceAppointmentCreateDto, ResourceAppointment>(input);
            //resourceAppointment.TenantId = CurrentTenant.Id;
            resourceAppointment = await _resourceAppointmentRepository.InsertAsync(resourceAppointment, autoSave: true);
            return _objectMapper.Map<ResourceAppointment, ResourceAppointmentDto>(resourceAppointment);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _resourceAppointmentRepository.DeleteAsync(id);
        }

        public virtual async Task DeleteIntAsync(int id)
        {
            await _resourceAppointmentRepository.DeleteIntAsync(id);
        }

        public virtual async Task<ResourceAppointmentDto> GetAsync(Guid id)
        {
            return _objectMapper.Map<ResourceAppointment, ResourceAppointmentDto>(await _resourceAppointmentRepository.GetAsync(id));
        }

        public virtual async Task<ResourceAppointmentDto> GetIntAsync(int id)
        {
            return _objectMapper.Map<ResourceAppointment, ResourceAppointmentDto>(await _resourceAppointmentRepository.GetIntAsync(id));
        }

        public virtual async Task<ResourceDto> FindByIntId(int Id)
        {
            var guid = await _resourceRepository.FindByIntId(Id);
            return _objectMapper.Map<Resource, ResourceDto>(await _resourceRepository.GetAsync(guid));
        }


        public virtual async Task<List<ResourceAppointmentWithNavigationPropertiesDto>> GetListAsync(GetResourceAppointmentsInput input)
        {
            var items = await _resourceAppointmentRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.AppointmentTypeMin, input.AppointmentTypeMax, 
                input.StartDateMin, input.StartDateMax, input.EndDateMin, input.EndDateMax, input.Caption, input.Description, input.Location, input.LabelMin, input.LabelMax,
                input.StatusMin, input.StatusMax, input.AllDay, input.Recurrence, input.ResourceIdMin, input.ResourceIdMax, input.ResourceAppointmentIDMin, input.ResourceAppointmentIDMax, 
                input.ResorceId);

            return _objectMapper.Map<List<ResourceAppointmentWithNavigationProperties>, List<ResourceAppointmentWithNavigationPropertiesDto>>(items);

        }

        public virtual async Task<ResourceAppointmentWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _objectMapper.Map<ResourceAppointmentWithNavigationProperties, ResourceAppointmentWithNavigationPropertiesDto>
                 (await _resourceAppointmentRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ResourceAppointmentDto> UpdateAsync(Guid id, ResourceAppointmentUpdateDto input)
        {
            var resourceAppointment = await _resourceAppointmentRepository.GetAsync(id);
            _objectMapper.Map(input, resourceAppointment);
            resourceAppointment = await _resourceAppointmentRepository.UpdateAsync(resourceAppointment);
            return _objectMapper.Map<ResourceAppointment, ResourceAppointmentDto>(resourceAppointment);
        }
    }
}
