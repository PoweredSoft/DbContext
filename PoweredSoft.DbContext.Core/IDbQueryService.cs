using System.Linq;

namespace PoweredSoft.DbContext.Core
{
    public interface IDbQueryService : IOrderedQueryable
    {
        IDbQueryService AsNoTracking();
        IDbQueryService Include(string path);
    }
}
