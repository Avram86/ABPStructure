using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Structure.Domain.Resources
{
    [System.ComponentModel.DataAnnotations.Schema.Table("resources")]
    public class Resource
    {
        [System.ComponentModel.DataAnnotations.Key]
        public virtual Guid Id { get; set; }
        [Required]
        public virtual string DoctorName { get; set; }

        public virtual TextCss TextCss { get; set; }

        public virtual BackgroundCss BackgroundCss { get; set; }

        public virtual int? GroupId { get; set; }

        public virtual bool IsGroup { get; set; }

        public virtual Specializari Name { get; set; }

        public virtual int ResourceId { get; set; }

        public Resource()
        {

        }

        public Resource(Guid id, string doctorName, TextCss textCss, BackgroundCss backgroundCss, bool isGroup, Specializari name, int resourceId, int? groupId = null)
        {
            Id = id;
            DoctorName = doctorName;
            TextCss = textCss;
            BackgroundCss = backgroundCss;
            IsGroup = isGroup;
            Name = name;
            ResourceId = resourceId;
            GroupId = groupId;
        }

        //added for DevExpress
        public override bool Equals(object obj)
        {
            Resource resource = obj as Resource;
            return resource != null && resource.Id == Id;
        }
        public override int GetHashCode()
        {
            return ResourceId;
        }
    }
}