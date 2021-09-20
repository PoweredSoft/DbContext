using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.DbContext
{
    public class QueryableExtensionService : IQueryableExtensionService
    {
        private readonly IEnumerable<IQueryableService> services;

        public QueryableExtensionService(IEnumerable<IQueryableService> services)
        {
            this.services = services;
        }

        public IQueryableService ResolveService<T>(IQueryable<T> queryable)
        {
            var service = this.services.FirstOrDefault(t => t.CanHandle(queryable));
            if (service == null)
                throw new Exception($"Could not resolve any service to execute operation..");

            return service;
        }

        public IQueryableService ResolveService(IQueryable queryable)
        {
            var service = this.services.FirstOrDefault(t => t.CanHandle(queryable));
            if (service == null)
                throw new Exception($"Could not resolve any service to execute operation..");

            return service;
        }

        public IQueryable<T> AsNoTracking<T>(IQueryable<T> source) where T : class 
            => ResolveService(source).AsNoTracking(source);

        public IQueryable AsNoTracking(IQueryable source)
            => ResolveService(source).AsNoTracking(source);

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
            => ResolveService(source).FirstOrDefaultAsync(source, cancellationToken: cancellationToken);

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
            => ResolveService(source).FirstOrDefaultAsync(source, predicate, cancellationToken: cancellationToken);

        public Task<T> FirstAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
            => ResolveService(source).FirstAsync(source, cancellationToken: cancellationToken);
        public Task<T> FirstAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
            => ResolveService(source).FirstAsync(source, predicate, cancellationToken: cancellationToken);

        public Task<bool> AnyAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
            => ResolveService(source).AnyAsync(source, cancellationToken: cancellationToken);

        public Task<bool> AnyAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
            => ResolveService(source).AnyAsync(source, predicate, cancellationToken: cancellationToken);

        public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
            where T : class
            => ResolveService(source).Include(source, path);

        public IQueryable<T> Include<T>(IQueryable<T> source, string path)
            where T : class
            => ResolveService(source).Include(source, path);

        public Task<List<T>> ToListAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default) where T : class
            => ResolveService(source).ToListAsync(source, cancellationToken: cancellationToken);

    }
}
