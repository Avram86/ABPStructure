using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Resource.Dto
{
    public class ResourceCreateDto
    {
        [Required]
        public string DoctorName { get; set; }
        public TextCss TextCss { get; set; } = ((TextCss[])Enum.GetValues(typeof(TextCss)))[0];
        public BackgroundCss BackgroundCss { get; set; } = ((BackgroundCss[])Enum.GetValues(typeof(BackgroundCss)))[0];
        public int? GroupId { get; set; }
        public bool IsGroup { get; set; }
        public Specializari Name { get; set; } = ((Specializari[])Enum.GetValues(typeof(Specializari)))[0];
        public int ResourceId { get; set; }
    }
}
