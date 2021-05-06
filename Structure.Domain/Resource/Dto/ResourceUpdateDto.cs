using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Resource.Dto
{
   public  class ResourceUpdateDto
    {
        [Required]
        public string DoctorName { get; set; }
        public TextCss TextCss { get; set; }
        public BackgroundCss BackgroundCss { get; set; }
        public int? GroupId { get; set; }
        public bool IsGroup { get; set; }
        public Specializari Name { get; set; }
        public int ResourceId { get; set; }
    }
}
