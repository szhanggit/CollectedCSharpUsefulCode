using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Core;
using System;
using System.Linq;

namespace Tenant.Api.Extensions
{
    public static class CoreServiceExtension
    {
        public static IServiceCollection AddCoreService(this IServiceCollection services, IConfiguration configuration)
        {
            var ns = typeof(GetTenantConfigService).Namespace;
            typeof(GetTenantConfigService).Assembly.GetTypes().Where(t => string.Equals(t.Namespace, ns, StringComparison.Ordinal))
                .ToList()
                .ForEach(fe =>
                {
                    services.AddScoped(fe);
                });

            return services;
        }
    }
}
