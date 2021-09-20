using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PoweredSoft.DbContext.Core
{
    public interface IDbSetService<TEntity> : IDbQueryService<TEntity>, IDbSetService
        where TEntity : class
    {
        new ICollection<TEntity> Local { get; }

        TEntity Add(TEntity entity);
        TEntity Remove(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Attach(TEntity entity);
    }
}
