using Structure.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.Repositories
{
    public interface IBasicRepository<TEntity> : IReadOnlyBasicRepository<TEntity>, IRepository where TEntity : class, IEntity
    {
        //
        // Summary:
        //     Deletes an entity.
        //
        // Parameters:
        //   entity:
        //     Entity to be deleted
        //
        //   autoSave:
        //     Set true to automatically save changes to database. This is useful for ORMs /
        //     database APIs those only save changes with an explicit method call, but you need
        //     to immediately save changes to the database.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        //
        // Summary:
        //     Inserts a new entity.
        //
        // Parameters:
        //   autoSave:
        //     Set true to automatically save changes to database. This is useful for ORMs /
        //     database APIs those only save changes with an explicit method call, but you need
        //     to immediately save changes to the database.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        //   entity:
        //     Inserted entity
        Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        //
        // Summary:
        //     Updates an existing entity.
        //
        // Parameters:
        //   autoSave:
        //     Set true to automatically save changes to database. This is useful for ORMs /
        //     database APIs those only save changes with an explicit method call, but you need
        //     to immediately save changes to the database.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        //   entity:
        //     Entity
        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
    }
}
