using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.LabelObjects
{
    [System.ComponentModel.DataAnnotations.Schema.Table("labelObjects")]
    public class LabelObject
    {
        [Key]
        public virtual Guid Id { get; set; }

        public virtual int LabelObjectId { get; set; }

        [CanBeNull]
        public virtual string LabelCaption { get; set; }

        public virtual TextCssClass TextCssClass { get; set; }

        public virtual BackgroundCssClass BackgroundCssClass { get; set; }

        public LabelObject()
        {

        }

        public LabelObject(Guid id, int labelObjectId, string labelCaption, TextCssClass textCssClass, BackgroundCssClass backgroundCssClass)
        {
            Id = id;
            LabelObjectId = labelObjectId;
            LabelCaption = labelCaption;
            TextCssClass = textCssClass;
            BackgroundCssClass = backgroundCssClass;
        }
    }
}