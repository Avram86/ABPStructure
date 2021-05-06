using Structure.Application.Services;
using Structure.Domain.Consultatii.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii
{
    public interface IConsultatieAppService: IApplicationService
    {
        Task<List<ConsultatieWithNavigationPropertiesDto>> GetListAsync(GetConsultatiiInput input);

        Task<ConsultatieWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ConsultatieDto> GetAsync(Guid id);

        //Task<PagedResultDto<LookupDto<Guid?>>> GetPatientLookupAsync(LookupRequestDto input);

        //Task<PagedResultDto<LookupDto<Guid?>>> GetResourceLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<ConsultatieDto> CreateAsync(ConsultatieCreateDto input);

        Task<ConsultatieDto> UpdateAsync(Guid id, ConsultatieUpdateDto input);
    }
}
