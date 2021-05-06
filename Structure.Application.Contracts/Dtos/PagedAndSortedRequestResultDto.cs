using System.ComponentModel.DataAnnotations;

namespace Structure.Domain.LabelObjects.Dto
{
    public class PagedAndSortedRequestResultDto
    {
        public virtual string Sorting { get; set; }

        //[Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }

        public static int DefaultMaxResultCount { get; set; }
        //
        // Summary:
        //     Maximum possible value of the Volo.Abp.Application.Dtos.LimitedResultRequestDto.MaxResultCount.
        //     Default value: 1,000.
        public static int MaxMaxResultCount { get; set; }
        //
        // Summary:
        //     Maximum result count should be returned. This is generally used to limit result
        //     count on paging.
        //[Range(1, int.MaxValue)]
        public virtual int MaxResultCount { get; set; }
    }
}