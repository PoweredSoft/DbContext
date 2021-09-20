using PoweredSoft.DbContext.Core;
using PoweredSoft.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace PoweredSoft.DbContext.EntityFrameworkCore
{
    public class DbContextService : IDbContextService
    {
        public DbContextService(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected Microsoft.EntityFrameworkCore.DbContext DbContext { get; }

        private MethodInfo setGenericMethodInfo = null;

        public IDbContextTransactionService BeginTransaction()
        {
            return new DbContextTransactionService(DbContext.Database.BeginTransaction());
        }

        public IEnumerable<PropertyInfo> GetKeyProperties(Type entityType)
        {
            var key = DbContext.Model.GetEntityTypes().First(t => t.ClrType == entityType).FindPrimaryKey();
            var keysProperties = key.Properties.Select(t => t.PropertyInfo);
            return keysProperties;
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

        [MethodKey("SetGeneric")]
        public IDbSetService<TEntity> Set<TEntity>() where TEntity : class
        {
            var realDbSet = DbContext.Set<TEntity>();
            var dbSet = new DbSetService<TEntity>(realDbSet);
            return dbSet;
        }

        public IDbSetService Set(Type entityType)
        {
            if (setGenericMethodInfo == null)
                setGenericMethodInfo = this.GetType().GetMethodByKey("SetGeneric", BindingFlags.Public | BindingFlags.Instance);

            var method = setGenericMethodInfo.MakeGenericMethod(entityType);
            var result = method.Invoke(this, new object[] { }) as IDbSetService;
            return result;
        }
    }
}
