using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.LabelObjects.Dto
{
    public class LabelObjectDto
    {
        public int LabelObjectId { get; set; }
        public string LabelCaption { get; set; }
        public TextCssClass TextCssClass { get; set; }
        public BackgroundCssClass BackgroundCssClass { get; set; }
    }
}
