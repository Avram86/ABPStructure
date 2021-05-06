using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Data
{
     public class StructureDbMigrationService
    {
        private readonly IEnumerable<IStructureDbSchemaMigrator> _dbSchemaMigrators;

        public ILogger<StructureDbMigrationService> Logger { get; set; }
        public StructureDbMigrationService(IEnumerable<IStructureDbSchemaMigrator> dbSchemaMigrators)
        {
            _dbSchemaMigrators = dbSchemaMigrators;

            Logger = NullLogger<StructureDbMigrationService>.Instance;
        }


        public async Task MigrateAsync()
        {
            await MigrateDatabaseSchemaAsync();

            Logger.LogInformation($"Successfully completed host database migrations.");
        }

        private async Task MigrateDatabaseSchemaAsync()
        {
            Logger.LogInformation("Migrating schema for database...");

            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }
        }
    }
}
