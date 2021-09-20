using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.DbContext.EntityFramework
{
    public class EntityFrameworkDbContextServiceFactory : IContextServiceFactory
    {
        private readonly IServiceProvider serviceProvider;

        public EntityFrameworkDbContextServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public bool CanService(Type contextType)
        {
            return typeof(System.Data.Entity.DbContext).IsAssignableFrom(contextType);
        }

        public IDbContextService Create(Type contextType)
        {
            var service = serviceProvider.GetService(contextType) as System.Data.Entity.DbContext;
            var contextService = new DbContextService(service);
            return contextService;
        }
    }
}
