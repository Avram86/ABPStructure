using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.LabelObjects.Dto
{
    public class LabelObjectCreateDto
    {
        public int LabelObjectId { get; set; }
        public string LabelCaption { get; set; }
        public TextCssClass TextCssClass { get; set; } = ((TextCssClass[])Enum.GetValues(typeof(TextCssClass)))[0];
        public BackgroundCssClass BackgroundCssClass { get; set; } = ((BackgroundCssClass[])Enum.GetValues(typeof(BackgroundCssClass)))[0];
    }
}
