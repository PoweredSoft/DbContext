using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace PoweredSoft.DbContext.EntityFramework
{
    public class DbContextService : IDbContextService
    {
        public DbContextService(System.Data.Entity.DbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected System.Data.Entity.DbContext DbContext { get; }

        public IDbContextTransactionService BeginTransaction()
        {
            return new DbContextTransactionService(DbContext.Database.BeginTransaction());
        }

        public IEnumerable<PropertyInfo> GetKeyProperties(Type entityType)
        {
            var metadata = ((IObjectContextAdapter)DbContext).ObjectContext.MetadataWorkspace;

            // Get the mapping between CLR types and metadata OSpace
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));

            // Get metadata for given CLR type
            var entityMetadata = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                    .Single(e => objectItemCollection.GetClrType(e) == entityType);

            var ret = entityMetadata.KeyProperties.Select(t => entityType.GetProperty(t.Name));
            return ret;
        }

        public IEnumerable<Expression<Func<TEntity, object>>> GetKeyProperties<TEntity>()
        {
            var keyProps = GetKeyProperties(typeof(TEntity));

            var parameter = Expression.Parameter(typeof(TEntity));
            var result = keyProps
                .Select(keyProp =>
                {
                    var property = Expression.Property(parameter, keyProp);
                    var lambda = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(property, typeof(Object)), parameter);
                    return (Expression<Func<TEntity, object>>)lambda;
                })
                .ToList();
            return result;
        }

        public T GetUnderlyingOrm<T>() where T : class
        {
            return this.DbContext as T;
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public IDbSetService<TEntity> Set<TEntity>() where TEntity : class
        {
            var realDbSet = DbContext.Set<TEntity>();
            var dbSet = new DbSetService<TEntity>(realDbSet);
            return dbSet;
        }

        public IDbSetService Set(Type entityType)
        {
            var realDbSet = DbContext.Set(entityType);
            var dbSet = new DbSetService(realDbSet);
            return dbSet;
        }
    }
}
