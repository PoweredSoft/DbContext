using System;

namespace PoweredSoft.DbContext.Core
{
    public interface IDbContextServiceProvider
    {
        IDbContextService GetServiceForType<TContext>();
        IDbContextService GetServiceForType(Type contextType);
    }

    public interface IContextServiceFactory
    {
        bool CanService(Type contextType);
        IDbContextService Create(Type contextType);
    }
}
