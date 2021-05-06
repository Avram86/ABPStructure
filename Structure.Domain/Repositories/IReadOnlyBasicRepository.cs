using Structure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.Repositories
{
    public interface IReadOnlyBasicRepository<TEntity> : IRepository where TEntity : class, IEntity
    {
        //
        // Summary:
        //     Gets total count of all entities.
        Task<long> GetCountAsync(CancellationToken cancellationToken = default);
        //
        // Summary:
        //     Gets a list of all the entities.
        //
        // Parameters:
        //   includeDetails:
        //     Set true to include all children of this entity
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     Entity
        Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default);
    }
}
