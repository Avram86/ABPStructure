using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Data
{
    public interface IStructureDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
