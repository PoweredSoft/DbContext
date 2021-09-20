using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace PoweredSoft.DbContext.Core
{
    public interface IDbContextService
    {
        IDbSetService<TEntity> Set<TEntity>() where TEntity : class;
        IDbSetService Set(Type entityType);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        T GetUnderlyingOrm<T>() where T : class;
        IEnumerable<PropertyInfo> GetKeyProperties(Type entityType);
        IEnumerable<Expression<Func<TEntity, object>>> GetKeyProperties<TEntity>();
        IDbContextTransactionService BeginTransaction();
    }
}
