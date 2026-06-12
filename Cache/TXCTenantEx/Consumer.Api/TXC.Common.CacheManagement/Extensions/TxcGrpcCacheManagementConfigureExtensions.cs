using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXC.Common.CacheManagement.GrpcServices;

namespace TXC.Common.CacheManagement.Extensions
{
    public static class TxcGrpcCacheManagementConfigureExtensions
    {
        public static void ConfigureTxcGrpcDistributedCache(this IServiceCollection services, bool isDevelopment, IConfiguration configuration)
        {
            services.AddSingleton<GrpcTenantConfigCacheRead>();
            services.AddGrpcClient<TXC.Proto.Tenant.TenantConfig.TenantConfigClient>(o =>
            {
                o.Address = new Uri(configuration["Cache:TenantConfig:Uri"]);
            });
        }
    }
}
