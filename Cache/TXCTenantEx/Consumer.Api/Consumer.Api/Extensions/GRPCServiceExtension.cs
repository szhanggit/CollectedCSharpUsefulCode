using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TXC.Proto.Tenant;

namespace Consumer.Api.Extensions
{
    public static class GRPCServiceExtension
    {
        public static IServiceCollection AddgRPCService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<Tenant.TenantClient>(o =>
            {
                o.Address = new Uri(configuration["Cache:TenantConfig:Uri"]);
            });

            return services;
        }
    }
}
