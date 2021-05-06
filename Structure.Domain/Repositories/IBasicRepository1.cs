using Structure.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.Repositories
{
    //public interface IBasicRepository<TEntity, TKey> : IBasicRepository<TEntity>, IReadOnlyBasicRepository<TEntity>, IRepository, IReadOnlyBasicRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    //{
    //    //
    //    // Summary:
    //    //     Deletes an entity by primary key.
    //    //
    //    // Parameters:
    //    //   id:
    //    //     Primary key of the entity
    //    //
    //    //   autoSave:
    //    //     Set true to automatically save changes to database. This is useful for ORMs /
    //    //     database APIs those only save changes with an explicit method call, but you need
    //    //     to immediately save changes to the database.
    //    //
    //    //   cancellationToken:
    //    //     A System.Threading.CancellationToken to observe while waiting for the task to
    //    //     complete.
    //    Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default);
    //}
}