using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Core;

namespace Tenant.Api.Extensions
{
    public static class GRPCServiceExtension
    {
        public static IServiceCollection AddgRPCService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGetTenantConfigService, GetTenantConfigService>();

            return services;
        }
    }
}
