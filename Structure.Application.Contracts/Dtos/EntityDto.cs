using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application.Contracts.Dtos
{
    public abstract class EntityDto<TKey> :EntityDto,  IEntityDto
    {
        protected EntityDto() { }

        //
        // Summary:
        //     Id of the entity.
        public TKey Id { get; set; }

        //public override string ToString();
    }
}
