using Microsoft.Extensions.DependencyInjection;
using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.DbContext.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftEntityFrameworkCoreDbContextServices(this IServiceCollection services)
        {
            services.AddSingleton<IQueryableService, EntityFrameworkCoreQueryableService>();
            services.AddSingleton<IContextServiceFactory, EntityFrameworkCoreDbContextServiceFactory>();
            return services;
        }
    }
}
