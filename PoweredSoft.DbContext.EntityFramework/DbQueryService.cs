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
    public class DbQueryService : IDbQueryService
    {
        public DbQueryService(DbQuery dbQuery)
        {
            DbQuery = dbQuery;
        }

        public Expression Expression => ((IQueryable)DbQuery).Expression;

        public Type ElementType => ((IQueryable)DbQuery).ElementType;

        public IQueryProvider Provider => ((IQueryable)DbQuery).Provider;

        protected DbQuery DbQuery { get; }

        public IDbQueryService AsNoTracking()
        {
            var efQuery = DbQuery.AsNoTracking();
            var ret = new DbQueryService(efQuery);
            return ret;
        }

        public IEnumerator GetEnumerator() => ((IQueryable)DbQuery).GetEnumerator();

        public IDbQueryService Include(string path)
        {
            var efQuery = DbQuery.Include(path);
            var ret = new DbQueryService(efQuery);
            return ret;
        }
    }
}
