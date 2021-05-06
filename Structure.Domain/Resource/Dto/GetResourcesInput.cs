using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Resource.Dto
{
    public class GetResourcesInput
    {
        public string FilterText { get; set; }

        public string DoctorName { get; set; }
        public TextCss? TextCss { get; set; }
        public BackgroundCss? BackgroundCss { get; set; }
        public int? GroupIdMin { get; set; }
        public int? GroupIdMax { get; set; }
        public bool? IsGroup { get; set; }
        public Specializari? Name { get; set; }
        public int? ResourceIdMin { get; set; }
        public int? ResourceIdMax { get; set; }

        public GetResourcesInput()
        {

        }
    }
}
