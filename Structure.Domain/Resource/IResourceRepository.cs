using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.Resources
{
    public interface IResourceRepository
    {
        Task<List<Resource>> GetListAsync(
              string filterText = null,
        string doctorName = null,
        TextCss? textCss = null,
        BackgroundCss? backgroundCss = null,
        int? groupIdMin = null,
        int? groupIdMax = null,
        bool? isGroup = null,
        Specializari? name = null,
        int? resourceIdMin = null,
        int? resourceIdMax = null,
        CancellationToken cancellationToken=default);

        Task<long> GetCountAsync(
              string filterText = null,
        string doctorName = null,
        TextCss? textCss = null,
        BackgroundCss? backgroundCss = null,
         int? groupIdMin = null,
         int? groupIdMax = null,
         bool? isGroup = null,
         Specializari? name = null,
         int? resourceIdMin = null,
         int? resourceIdMax = null,
         CancellationToken cancellationToken = default);

        Task<Guid> FindByIntId(int Id);
        Task<Resource> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<Resource> InsertAsync(Resource resource, bool autoSave);
        Task<Resource> UpdateAsync(Resource resource);

    }
}
