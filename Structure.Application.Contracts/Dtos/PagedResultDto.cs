using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application.Dtos
{
    public class PagedResultDto<T> : ListResultDto<T>, IPagedResult<T>, IListResult<T>, IHasTotalCount
    {
        //
        // Summary:
        //     Creates a new Volo.Abp.Application.Dtos.PagedResultDto`1 object.
        public PagedResultDto() { }
        //
        // Summary:
        //     Creates a new Volo.Abp.Application.Dtos.PagedResultDto`1 object.
        //
        // Parameters:
        //   totalCount:
        //     Total count of Items
        //
        //   items:
        //     List of items in current page
        public PagedResultDto(long totalCount, IReadOnlyList<T> items) { }

        public long TotalCount { get; set; }
    }
}
