using System.Linq;

namespace PoweredSoft.DbContext.Core
{
    public interface IDbQueryService<TEntity> : IOrderedQueryable<TEntity>, IDbQueryService
        where TEntity : class
    {
    }
}
