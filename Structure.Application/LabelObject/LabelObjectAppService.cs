
using AutoMapper;

using Structure.Domain.LabelObjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.LabelObjects
{
    public class LabelObjectAppService : ILabelObjectAppService
    {
        private readonly ILabelObjectRepository _labelObjectRepository;
        private readonly IMapper _objectMapper;

        public LabelObjectAppService(ILabelObjectRepository labelObjectRepository, IMapper objectMapper)
        {
            _labelObjectRepository = labelObjectRepository;
            _objectMapper = objectMapper;
        }
        public virtual async Task<LabelObjectDto> CreateAsync(LabelObjectCreateDto input)
        {
            var labelObject = _objectMapper.Map<LabelObjectCreateDto, Structure.Domain.LabelObjects.LabelObject>(input);
            //labelObject.TenantId = CurrentTenant.Id;
            labelObject = await _labelObjectRepository.InsertAsync(labelObject, autoSave: true);
            labelObject.LabelObjectId = BitConverter.ToInt32(labelObject.Id.ToByteArray(), 0);
            return _objectMapper.Map<Structure.Domain.LabelObjects.LabelObject, LabelObjectDto>(labelObject);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _labelObjectRepository.DeleteAsync(id);
        }

        public virtual async Task<LabelObjectDto> GetAsync(Guid id)
        {
            return _objectMapper.Map<Structure.Domain.LabelObjects.LabelObject, LabelObjectDto>(await _labelObjectRepository.GetAsync(id));
        }

        public virtual async Task<List<LabelObjectDto>> GetListAsync(GetLabelObjectsInput input)
        {
            var items = await _labelObjectRepository.GetListAsync(input.FilterText, input.LabelObjectIdMin, input.LabelObjectIdMax, input.LabelCaption, input.TextCssClass,
                input.BackgroundCssClass);

            return _objectMapper.Map<List<Structure.Domain.LabelObjects.LabelObject>, List<LabelObjectDto>>(items);

        }

        public virtual async Task<LabelObjectDto> UpdateAsync(Guid id, LabelObjectUpdateDto input)
        {
            var labelObject = await _labelObjectRepository.GetAsync(id);
            _objectMapper.Map(input, labelObject);
            labelObject = await _labelObjectRepository.UpdateAsync(labelObject);
            return _objectMapper.Map<Structure.Domain.LabelObjects.LabelObject, LabelObjectDto>(labelObject);
        }
    }
}
