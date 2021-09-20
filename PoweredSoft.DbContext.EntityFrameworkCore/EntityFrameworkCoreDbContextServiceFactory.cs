using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.DbContext.EntityFrameworkCore
{
    public class EntityFrameworkCoreDbContextServiceFactory : IContextServiceFactory
    {
        private readonly IServiceProvider serviceProvider;

        public EntityFrameworkCoreDbContextServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public bool CanService(Type contextType)
        {
            return typeof(Microsoft.EntityFrameworkCore.DbContext).IsAssignableFrom(contextType);
        }

        public IDbContextService Create(Type contextType)
        {
            var service = serviceProvider.GetService(contextType) as Microsoft.EntityFrameworkCore.DbContext;
            var contextService = new DbContextService(service);
            return contextService;
        }
    }
}
