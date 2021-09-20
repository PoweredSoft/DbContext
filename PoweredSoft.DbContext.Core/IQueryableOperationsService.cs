using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.DbContext.Core
{
    public interface IQueryableOperationsService
    {
        IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) 
            where T : class;
        IQueryable<T> AsNoTracking<T>(IQueryable<T> source) 
            where T : class;
        IQueryable AsNoTracking(IQueryable source);
        IQueryable<T> Include<T>(IQueryable<T> source, string path)
            where T : class;
        Task<T> FirstOrDefaultAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class;
        Task<T> FirstOrDefaultAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default) where T : class;
        Task<T> FirstAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class;
        Task<T> FirstAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default) where T : class;
        Task<List<T>> ToListAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class;

        Task<bool> AnyAsync<T>(IQueryable<T> source, System.Linq.Expressions.Expression<System.Func<T, bool>> predicate, CancellationToken cancellationToken) where T : class;
        Task<bool> AnyAsync<T>(IQueryable<T> source, CancellationToken cancellationToken) where T : class;
    }
}
