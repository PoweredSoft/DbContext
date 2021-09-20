using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.DbContext.Core
{
    public static class DbContextQueryableExtensions
    {
        private static IQueryableExtensionService service;

        public static void InitializeExtensionService(IQueryableExtensionService queryableService)
        {
            service = queryableService;
        }

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path)
            where T : class
            => service.Include(source, path);

        public static IQueryable AsNoTracking(this IQueryable source)
            => service.AsNoTracking(source);

        public static IQueryable<T> AsNoTracking<T>(this IQueryable<T> source) where T : class
            => service.AsNoTracking(source);

        public static IQueryable<T> Include<T>(this IQueryable<T> source, string path)
            where T : class
            => service.Include(source, path);

        public static Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> source,
            CancellationToken cancellationToken = default) where T : class =>
            service.FirstOrDefaultAsync(source, cancellationToken);

        public static Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> source,
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default) where T : class =>
            service.FirstOrDefaultAsync(source, predicate, cancellationToken);

        public static Task<T> FirstAsync<T>(this IQueryable<T> source,
            CancellationToken cancellationToken = default) where T : class =>
            service.FirstAsync(source, cancellationToken);

        public static Task<T> FirstAsync<T>(this IQueryable<T> source,
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default) where T : class =>
            service.FirstAsync(source, predicate, cancellationToken);

        public static Task<bool> AnyAsync<T>(this IQueryable<T> source,
            CancellationToken cancellationToken = default) where T : class =>
            service.AnyAsync(source, cancellationToken);

        public static Task<bool> AnyAsync<T>(this IQueryable<T> source,
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default) where T : class =>
            service.AnyAsync(source, predicate, cancellationToken);

        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> source,
            CancellationToken cancellationToken = default) where T : class =>
            service.ToListAsync(source, cancellationToken);
    }
}
