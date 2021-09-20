using PoweredSoft.DbContext.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PoweredSoft.DbContext.EntityFramework
{
    public class DbQueryService<TEntity> : IDbQueryService<TEntity>
        where TEntity : class
    {
        public DbQueryService(DbQuery<TEntity> dbQuery)
        {
            DbQuery = dbQuery;
        }

        public Expression Expression => ((IQueryable<TEntity>)DbQuery).Expression;

        public Type ElementType => ((IQueryable<TEntity>)DbQuery).ElementType;

        public IQueryProvider Provider => ((IQueryable<TEntity>)DbQuery).Provider;

        protected DbQuery<TEntity> DbQuery { get; }

        public IDbQueryService<TEntity> AsNoTracking()
        {
            var efQuery = DbQuery.AsNoTracking();
            var ret = new DbQueryService<TEntity>(efQuery);
            return ret;
        }

        public IEnumerator GetEnumerator() => ((IQueryable<TEntity>)DbQuery).GetEnumerator();

        public IDbQueryService<TEntity> Include(string path)
        {
            var efQuery = DbQuery.Include(path);
            var ret = new DbQueryService<TEntity>(efQuery);
            return ret;
        }

        IDbQueryService IDbQueryService.AsNoTracking()
        {
            var efQuery = DbQuery.AsNoTracking();
            var ret = new DbQueryService<TEntity>(efQuery);
            return ret;
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => ((IQueryable<TEntity>)DbQuery).GetEnumerator();

        IDbQueryService IDbQueryService.Include(string path)
        {
            var efQuery = DbQuery.Include(path);
            var ret = new DbQueryService<TEntity>(efQuery);
            return ret;
        }
    }
}
