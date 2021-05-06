using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.LabelObjects.Dto
{
    public class GetLabelObjectsInput:PagedAndSortedRequestResultDto
    {
        public string FilterText { get; set; }

        public int? LabelObjectIdMin { get; set; }
        public int? LabelObjectIdMax { get; set; }
        public string LabelCaption { get; set; }
        public TextCssClass? TextCssClass { get; set; }
        public BackgroundCssClass? BackgroundCssClass { get; set; }

        public GetLabelObjectsInput()
        {

        }
    }
}
