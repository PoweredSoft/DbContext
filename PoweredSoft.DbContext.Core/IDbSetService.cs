using System.Collections;

namespace PoweredSoft.DbContext.Core
{
    public interface IDbSetService : IDbQueryService
    {
        IList Local { get; }

        object Add(object entity);
        void AddRange(IEnumerable entities);
        object Remove(object entity);
        void RemoveRange(IEnumerable entities);
        object Find(params object[] keyValues);
        object Attach(object entity);
    }
}
