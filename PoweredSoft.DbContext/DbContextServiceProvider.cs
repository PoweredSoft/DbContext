using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.DbContext
{
    public class DbContextServiceProvider : IDbContextServiceProvider
    {
        private readonly IEnumerable<IContextServiceFactory> factories;

        public DbContextServiceProvider(IEnumerable<IContextServiceFactory> factories)
        {
            this.factories = factories;
        }

        public IDbContextService GetServiceForType<TContext>()
        {
            return GetServiceForType(typeof(TContext));
        }

        public IDbContextService GetServiceForType(Type contextType)
        {
            var factory = factories.FirstOrDefault(t => t.CanService(contextType));
            if (factory == null)
                throw new NotSupportedException($"Could not resolve which factory should create a context service for {contextType}");

            return factory.Create(contextType);
        }
    }
}
