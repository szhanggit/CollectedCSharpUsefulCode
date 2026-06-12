using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXC.Common.CacheManagement.GrpcServices;
using TXC.Common.CacheManagement.Interface;
using TXC.Common.Domain;

namespace TXC.Common.CacheManagement.Resolver
{
    public interface ITenantConfigHelper
    {
        Task<TenantConfig> GetTenantConfigValue(string configName, int tenantId);
    }

    public class TenantConfigHelper : ITenantConfigHelper
    {
        private readonly IServiceProvider _provider;
        public TenantConfigHelper(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TenantConfig> GetTenantConfigValue(string configName, int tenantId)
        {
            //check tx2 connector config
            ITxcCacheRead tenantConfigCache = this._provider.GetService<GrpcTenantConfigCacheRead>();

            //this will get from local cache or redis cache
            string tenantConfigStr = await tenantConfigCache.GetAsync(new System.Collections.Generic.Dictionary<string, string>() { { "TenantId", tenantId.ToString() } });

            TenantConfig config = null;
            if (!string.IsNullOrEmpty(tenantConfigStr))
            {
                IEnumerable<TenantConfig> tenantConfigs = JsonConvert.DeserializeObject<IEnumerable<TenantConfig>>(tenantConfigStr);
                config = tenantConfigs.FirstOrDefault(t => t.ConfigName.Equals(configName));
                if (config == null)
                    throw new Exception($"Missing {configName} Config for Tenant");

                return config;
            }
            else
                throw new Exception("No Tenant Config Found");
        }
    }
}
