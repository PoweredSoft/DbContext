using PoweredSoft.DbContext.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace PoweredSoft.DbContext.EntityFramework
{
    public class DbSetService : DbQueryService, IDbSetService
    {
        protected DbSet DbSet { get; }

        public DbSetService(DbSet dbSet) : base(dbSet)
        {
            DbSet = dbSet;
        }

        public IList Local => DbSet.Local;

        public object Add(object entity) => DbSet.Add(entity);

        public object Remove(object entity) => DbSet.Remove(entity);
        public void AddRange(IEnumerable entities) => DbSet.AddRange(entities);
        public void RemoveRange(IEnumerable entities) => DbSet.RemoveRange(entities);

        public object Find(params object[] keyValues) => DbSet.Find(keyValues);

        public object Attach(object entity) => DbSet.Attach(entity);
    }
}
