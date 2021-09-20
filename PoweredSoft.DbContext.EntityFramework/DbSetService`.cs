using PoweredSoft.DbContext.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PoweredSoft.DbContext.EntityFramework
{
    public class DbSetService<TEntity> : DbQueryService<TEntity>, IDbSetService<TEntity>
        where TEntity : class
    {
        public DbSetService(DbSet<TEntity> dbSet) : base(dbSet)
        {
            DbSet = dbSet;
        }

        protected DbSet<TEntity> DbSet { get; }

        public ICollection<TEntity> Local => DbSet.Local;

        IList IDbSetService.Local => DbSet.Local;

        public TEntity Add(TEntity entity) => DbSet.Add(entity);

        public TEntity Remove(TEntity entity) => DbSet.Remove(entity);

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => ((IQueryable<TEntity>)DbSet).GetEnumerator();

        public TEntity Create() => DbSet.Create();

        public TEntity Attach(TEntity entity) => DbSet.Attach(entity);

        public DbSet<TEntity> GetEntityFrameworkSet() => DbSet;

        public TEntity Find(params object[] keyValues) => DbSet.Find(keyValues);

        void IDbSetService<TEntity>.AddRange(IEnumerable<TEntity> entities) => DbSet.AddRange(entities);

        void IDbSetService<TEntity>.RemoveRange(IEnumerable<TEntity> entities) => DbSet.RemoveRange(entities);

        public object Add(object entity) => DbSet.Add((TEntity)entity);

        public void AddRange(IEnumerable entities)  => DbSet.AddRange(entities.Cast<TEntity>());

        public object Remove(object entity) => DbSet.Remove((TEntity)entity);

        public void RemoveRange(IEnumerable entities) => DbSet.RemoveRange(entities.Cast<TEntity>());

        object IDbSetService.Find(params object[] keyValues) => DbSet.Find(keyValues);

        public object Attach(object entity) => DbSet.Attach((TEntity)entity);
    }
}
