using Microsoft.EntityFrameworkCore;
using PoweredSoft.DbContext.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PoweredSoft.DbContext.EntityFrameworkCore
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

        IList IDbSetService.Local => DbSet.Local.ToList();

        public TEntity Add(TEntity entity) => DbSet.Add(entity).Entity;

        public TEntity Remove(TEntity entity) => DbSet.Remove(entity).Entity;

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => ((IQueryable<TEntity>)DbSet).GetEnumerator();


        public TEntity Attach(TEntity entity) => DbSet.Attach(entity).Entity;

        public void AddRange(IEnumerable<TEntity> entities) => DbSet.AddRange(entities);

        public void RemoveRange(IEnumerable<TEntity> entities) => DbSet.RemoveRange(entities);

        public DbSet<TEntity> GetEntityFrameworkSet() => DbSet;

        public TEntity Find(params object[] keyValues) => DbSet.Find(keyValues);

        public object Add(object entity) => DbSet.Add((TEntity)entity);

        public void AddRange(IEnumerable entities) => DbSet.AddRange(entities.Cast<TEntity>());

        public object Remove(object entity) => DbSet.Remove((TEntity)entity);

        public void RemoveRange(IEnumerable entities) => DbSet.RemoveRange(entities.Cast<TEntity>());

        object IDbSetService.Find(params object[] keyValues) => DbSet.Find(keyValues);

        public object Attach(object entity) => DbSet.Attach((TEntity)entity).Entity;
    }
}
