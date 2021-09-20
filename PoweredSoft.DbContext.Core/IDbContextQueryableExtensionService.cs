using System.Linq;

namespace PoweredSoft.DbContext.Core
{

    public interface IQueryableExtensionService : IQueryableOperationsService
    {
        IQueryableService ResolveService<T>(IQueryable<T> queryable);
        IQueryableService ResolveService(IQueryable queryable);
    }
}
