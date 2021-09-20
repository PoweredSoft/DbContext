using Microsoft.Extensions.DependencyInjection;
using PoweredSoft.DbContext.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.DbContext.EntityFramework
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftEntityFrameworkDbContextServices(this IServiceCollection services)
        {
            services.AddSingleton<IQueryableService, EntityFrameworkQueryableService>();
            services.AddSingleton<IContextServiceFactory, EntityFrameworkDbContextServiceFactory>();
            return services;
        }
    }
}
