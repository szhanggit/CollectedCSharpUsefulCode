using DistributedCacheEx.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistributedCacheEx.Extensions
{
    public static class TxcCacheManagementConfigureExtensions
    {
        public static void ConfigureTxcDistributedCache(this IServiceCollection services, bool isDevelopment, IConfiguration configuration)
        {
            if (isDevelopment)
            {
                services.AddDistributedMemoryCache();//cross APPs, but not cross machines.
            }
            else
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    var config = new RedisConfiguration();
                    configuration.Bind("Redis", config);
                    options.Configuration = config.ConnectionString;
                    options.InstanceName = config.InstanceName;
                });
            }
        }
    }
}
