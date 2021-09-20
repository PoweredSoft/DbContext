using System.Linq;
using System.Threading;

namespace PoweredSoft.DbContext.Core
{
    public interface IQueryableService : IQueryableOperationsService
    {
        bool CanHandle<T>(IQueryable<T> queryable);
        bool CanHandle(IQueryable queryable);
    }
}
