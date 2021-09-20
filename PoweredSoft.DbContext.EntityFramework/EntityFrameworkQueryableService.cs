using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.DbContext.EntityFramework
{
    public class EntityFrameworkQueryableService : IQueryableService
    {
        public Task<bool> AnyAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : class
        {
            return System.Data.Entity.QueryableExtensions.AnyAsync(source, predicate, cancellationToken);
        }

        public Task<bool> AnyAsync<T>(IQueryable<T> source, CancellationToken cancellationToken) where T : class
        {
            return System.Data.Entity.QueryableExtensions.AnyAsync(source, cancellationToken);
        }

        public IQueryable<T> AsNoTracking<T>(IQueryable<T> source) where T : class
        {
            return System.Data.Entity.QueryableExtensions.AsNoTracking(source);
        }

        public IQueryable AsNoTracking(IQueryable source)
        {
            return System.Data.Entity.QueryableExtensions.AsNoTracking(source);
        }

        public bool CanHandle<T>(IQueryable<T> queryable)
        {
            return queryable.Provider is System.Data.Entity.Infrastructure.IDbAsyncQueryProvider;
        }

        public bool CanHandle(IQueryable queryable)
        {
            return queryable.Provider is System.Data.Entity.Infrastructure.IDbAsyncQueryProvider;
        }

        public Task<T> FirstAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
        {
            return System.Data.Entity.QueryableExtensions.FirstAsync(source, cancellationToken);
        }

        public Task<T> FirstAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
        {
            return System.Data.Entity.QueryableExtensions.FirstAsync(source, predicate, cancellationToken);
        }

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source, cancellationToken);
        }

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source, predicate, cancellationToken);
        }

        public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
            where T : class
        {
            return System.Data.Entity.QueryableExtensions.Include(source, path);
        }

        public IQueryable<T> Include<T>(IQueryable<T> source, string path)
            where T : class
        {
            return System.Data.Entity.QueryableExtensions.Include(source, path);
        }

        public Task<List<T>> ToListAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
        {
            return System.Data.Entity.QueryableExtensions.ToListAsync(source, cancellationToken);
        }
    }
}
