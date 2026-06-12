using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TXC.Common.CacheManagement.Extensions;

namespace Consumer.Api.Extensions
{
    public static class CachedExtension
    {
        public static IServiceCollection AddCached(this IServiceCollection services, IConfiguration configuration)
        {
            //todo: change to env.IsDevelopment() once Redis is available
            services.ConfigureTxcDistributedCache(true, configuration);
            services.ConfigureTxcGrpcDistributedCache(true, configuration);
            services.AddMemoryCache();

            return services;
        }
    }
}
