using Structure.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Repositories
{
    public interface IReadOnlyRepository<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable, IReadOnlyBasicRepository<TEntity>, IRepository where TEntity : class, IEntity
    {
        IAsyncQueryableExecuter AsyncExecuter { get; }

        IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors);
        IQueryable<TEntity> WithDetails();
    }
}
