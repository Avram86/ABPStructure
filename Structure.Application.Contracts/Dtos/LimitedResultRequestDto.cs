using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Structure.Application.Dtos
{
    public class LimitedResultRequestDto : ILimitedResultRequest, IValidatableObject
    {
        public LimitedResultRequestDto() { }

        //
        // Summary:
        //     Default value: 10.
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }

        //[IteratorStateMachine(typeof(<Validate>d__12))]
        //public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}