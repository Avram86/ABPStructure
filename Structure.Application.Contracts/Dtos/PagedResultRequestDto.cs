using System.ComponentModel.DataAnnotations;

namespace Structure.Application.Dtos
{
    public class PagedResultRequestDto : LimitedResultRequestDto, IPagedResultRequest, ILimitedResultRequest
    {
        public PagedResultRequestDto() { }

        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }
    }
}