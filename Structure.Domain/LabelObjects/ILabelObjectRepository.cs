using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.LabelObjects
{
    public interface ILabelObjectRepository
    {
        Task<List<LabelObject>> GetListAsync(
            string filterText = null,
            int? labelObjectIdMin = null,
            int? labelObjectIdMax = null,
            string labelCaption = null,
            TextCssClass? textCssClass = null,
            BackgroundCssClass? backgroundCssClass = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
           string filterText = null,
           int? labelObjectIdMin = null,
           int? labelObjectIdMax = null,
           string labelCaption = null,
           TextCssClass? textCssClass = null,
           BackgroundCssClass? backgroundCssClass = null,
           CancellationToken cancellationToken = default);

        Task<LabelObject> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<LabelObject> InsertAsync(LabelObject labelObject, bool autoSave);
        Task<LabelObject> UpdateAsync(LabelObject labelObject);
    }
}
