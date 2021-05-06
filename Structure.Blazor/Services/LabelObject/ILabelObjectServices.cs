using Structure.Domain.LabelObjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.Blazor.Services.LabelObject
{
    public interface ILabelObjectServices
    {
        Task<List<LabelObjectDto>> GetList();
        Task<LabelObjectDto> GetLabel(Guid id);
        Task<LabelObjectDto> CreateLabel(LabelObjectCreateDto labelObjectCreate);
        Task<LabelObjectDto> UpdateLabel(Guid id, LabelObjectUpdateDto labelObjectUpdate);

        Task DeleteLabelObject(Guid id);
    }
}
