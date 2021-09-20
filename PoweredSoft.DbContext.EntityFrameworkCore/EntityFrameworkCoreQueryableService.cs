using Microsoft.EntityFrameworkCore.Query.Internal;
using PoweredSoft.DbContext.Core;
using PoweredSoft.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.DbContext.EntityFrameworkCore
{
    public class EntityFrameworkCoreQueryableService : IQueryableService
    {
        private MethodInfo asNoTrackingGeneric = null;

        public Task<bool> AnyAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.AnyAsync(source, predicate, cancellationToken);
        }

        public Task<bool> AnyAsync<T>(IQueryable<T> source, CancellationToken cancellationToken) where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.AnyAsync(source, cancellationToken);
        }

        [MethodKey("AsNoTrackingGeneric")]
        public IQueryable<T> AsNoTracking<T>(IQueryable<T> source) where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.AsNoTracking(source);
        }

        public IQueryable AsNoTracking(IQueryable source)
        {
            if (asNoTrackingGeneric == null)
                asNoTrackingGeneric = this.GetType().GetMethodByKey("AsNoTrackingGeneric");

            var elementType = source.ElementType;
            var method = asNoTrackingGeneric.MakeGenericMethod(elementType);
            var result = method.Invoke(this, new object[] { source });
            return result as IQueryable;
        }

        public bool CanHandle<T>(IQueryable<T> queryable)
        {
            return queryable.Provider is IAsyncQueryProvider;
        }

        public bool CanHandle(IQueryable queryable)
        {
            return queryable.Provider is IAsyncQueryProvider;
        }

        public Task<T> FirstAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstAsync(source, cancellationToken);
        }

        public Task<T> FirstAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstAsync(source, predicate, cancellationToken);
        }

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(source, cancellationToken);
        }

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(source, predicate, cancellationToken);
        }

        public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
            where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.Include(source, path);
        }

        public IQueryable<T> Include<T>(IQueryable<T> source, string path)
            where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.Include(source, path);
        }

        public Task<List<T>> ToListAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
        {
            return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(source, cancellationToken);
        }
    }
}
