using Microsoft.EntityFrameworkCore;
using PoweredSoft.DbContext.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PoweredSoft.DbContext.EntityFrameworkCore
{
    public class DbQueryService<TEntity> : IDbQueryService<TEntity>
        where TEntity : class
    {

        public DbQueryService(IQueryable<TEntity> queryable)
        {
            Queryable = queryable;
        }

        public Expression Expression => ((IQueryable<TEntity>)Queryable).Expression;

        public Type ElementType => ((IQueryable<TEntity>)Queryable).ElementType;

        public IQueryProvider Provider => ((IQueryable<TEntity>)Queryable).Provider;

        public IQueryable<TEntity> Queryable { get; }

        public IDbQueryService<TEntity> AsNoTracking()
        {
            var efQuery = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.AsNoTracking(Queryable);
            var ret = new DbQueryService<TEntity>(efQuery);
            return ret;
        }

        public IEnumerator GetEnumerator() => ((IQueryable<TEntity>)Queryable).GetEnumerator();

        public IDbQueryService<TEntity> Include(string path)
        {
            var efQuery = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.Include(Queryable, path);
            var ret = new DbQueryService<TEntity>(efQuery);
            return ret;
        }

        IDbQueryService IDbQueryService.AsNoTracking()
        {
            var efQuery = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.AsNoTracking(Queryable);
            var ret = new DbQueryService<TEntity>(efQuery);
            return ret;
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => ((IQueryable<TEntity>)Queryable).GetEnumerator();

        IDbQueryService IDbQueryService.Include(string path)
        {
            var efQuery = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.Include(Queryable, path);
            var ret = new DbQueryService<TEntity>(efQuery);
            return ret;
        }
    }
}
