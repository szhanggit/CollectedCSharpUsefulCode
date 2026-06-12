using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXC.Common.CacheManagement.Models;

namespace TXC.Common.CacheManagement.Extensions
{
    public static class TxcCacheManagementConfigureExtensions
    {
        public static void ConfigureTxcDistributedCache(this IServiceCollection services, bool isDevelopment, IConfiguration configuration)
        {
            if (isDevelopment)
            {
                services.AddDistributedMemoryCache();
            }
            else
            {
                //services.AddStackExchangeRedisCache(options =>
                //{
                //    var config = new RedisConfiguration();
                //    configuration.Bind("Redis", config);
                //    options.Configuration = config.ConnectionString;
                //    options.InstanceName = config.InstanceName;
                //});
                services.AddDistributedRedisCache(option => {
                    option.Configuration = $"{configuration.GetValue<string>("redis:master")}," +
                    $"password={configuration.GetValue<string>("redis:pass")}," +
                    $"defaultDatabase={configuration.GetValue<int>("redis:DatabaseId")}";
                    option.InstanceName = "master";
                });
            }
        }
    }
}
