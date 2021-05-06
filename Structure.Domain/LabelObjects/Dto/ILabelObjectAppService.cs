using Structure.Application.Services;
using Structure.Domain.LabelObjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.LabelObjects
{
    public interface ILabelObjectAppService:IApplicationService
    {
        Task<List<LabelObjectDto>> GetListAsync(GetLabelObjectsInput input);

        Task<LabelObjectDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<LabelObjectDto> CreateAsync(LabelObjectCreateDto input);

        Task<LabelObjectDto> UpdateAsync(Guid id, LabelObjectUpdateDto input);
    }
}
