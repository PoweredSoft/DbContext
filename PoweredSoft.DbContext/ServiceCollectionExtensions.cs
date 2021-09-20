using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.DbContext
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftDbContextServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IQueryableExtensionService, QueryableExtensionService>();
            services.TryAddSingleton<IDbContextServiceProvider, DbContextServiceProvider>();
            return services;
        }

        public static void InitPoweredSoftDbContextExtensions(this IServiceProvider serviceProvider)
        {
            var queryableExtensionService = serviceProvider.GetRequiredService<IQueryableExtensionService>();
            DbContextQueryableExtensions.InitializeExtensionService(queryableExtensionService);
        }
    }
}
