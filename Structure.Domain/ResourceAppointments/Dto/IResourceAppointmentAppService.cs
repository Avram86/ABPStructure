using Structure.Domain.ResourceAppointments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.ResourceAppointments
{
    public interface IResourceAppointmentAppService
    {
        Task<List<ResourceAppointmentWithNavigationPropertiesDto>> GetListAsync(GetResourceAppointmentsInput input);

        Task<ResourceAppointmentWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ResourceAppointmentDto> GetAsync(Guid id);
        Task<ResourceAppointmentDto> GetIntAsync(int id);

        //Task<List<LookupDto<Guid?>>> GetResorceLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);
        Task DeleteIntAsync(int id);

        Task<ResourceAppointmentDto> CreateAsync(ResourceAppointmentCreateDto input);

        Task<ResourceAppointmentDto> UpdateAsync(Guid id, ResourceAppointmentUpdateDto input);
    }
}
