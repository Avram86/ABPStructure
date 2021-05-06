using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Resource.Dto
{
    public class ResourceDto
    {
        public string DoctorName { get; set; }
        public TextCss TextCss { get; set; }
        public BackgroundCss BackgroundCss { get; set; }
        public int? GroupId { get; set; }
        public bool IsGroup { get; set; }
        public Specializari Name { get; set; }

        //returneaza valoarea pt grid reading
        public int ResourceId { get; set; }
        //{ get { return BitConverter.ToInt32(Id.ToByteArray(), 0); } }

        //added for DevExpress
        //public override bool Equals(object obj)
        //{
        //    ResourceDto resource = obj as ResourceDto;
        //    return resource != null && resource.Id == Id;
        //}
        public override int GetHashCode()
        {
            return ResourceId;
        }
    }
}
