using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TXC.Common.CacheManagement.Interface;
using TXC.Proto.Tenant;

namespace TXC.Common.CacheManagement.GrpcServices
{
    public class GrpcTenantConfigCacheRead : ITxcCacheRead
    {
        private readonly IMemoryCache _localCache;
        private readonly IDistributedCache _distCache;
        private int? _expirationSeconds = null;
        private string _serviceUri;
        private TenantConfig.TenantConfigClient _tenantConfigClient;

        private string configServiceUri = "Cache:TenantConfig:Uri";

        public GrpcTenantConfigCacheRead(IMemoryCache localCache, IDistributedCache distCache, TenantConfig.TenantConfigClient tenantConfigClient, IConfiguration configuration)
        {
            _localCache = localCache;
            _distCache = distCache;
            _tenantConfigClient = tenantConfigClient;
            _serviceUri = configuration[configServiceUri];

            var configExp = "Cache:TenantConfig:ExpirationSeconds";
            if (!string.IsNullOrEmpty(configuration[configExp]))
            {
                if (int.TryParse(configuration[configExp], out int expirationSeconds))
                    _expirationSeconds = expirationSeconds;
                else
                    throw new Exception($"Unable to parse {configExp}");
            }
        }

        public async Task<string> GetAsync(Dictionary<string, string> queryParams)
        {
            if (string.IsNullOrEmpty(_serviceUri))
                throw new System.Exception($"Missing appsettings {configServiceUri}");
            if (!queryParams.ContainsKey("TenantId"))
                throw new System.Exception($"Missing TenantId queryParams");

            var tenantId = int.Parse(queryParams["TenantId"]);
            var key = TxcCacheKeyGenerator.TenantConfigProgramCollection(tenantId);

            //Try to get from local cache first
            var cachedValue = _localCache.Get<string>(key);

            if (string.IsNullOrEmpty(cachedValue))
            {
                // Try to get the entity from the cache.
                cachedValue = await _distCache.GetStringAsync(key);

                if (string.IsNullOrEmpty(cachedValue)) // Cache miss
                {
                    // If there's a cache miss, get the entity from the original store and cache it.
                    try
                    {
                        var grpcResponse = await _tenantConfigClient.GetTenantConfigAsync(new GetTenantConfigRequest() { TenantId = tenantId });

                        if (grpcResponse.Success)
                        {
                            var data = grpcResponse.Data == null ? null : grpcResponse.Data.Unpack<GetTenantConfigResponse>().TenantConfigItems;

                            List<TenantConfigDto> configs = new List<TenantConfigDto>();
                            foreach (var d in data)
                            {
                                configs.Add(new TenantConfigDto()
                                {
                                    TenantId = d.TenantId,
                                    ConfigType = d.ConfigType,
                                    ConfigName = d.ConfigName,
                                    Version = d.Version,
                                    Value = d.Value,
                                    Comment = d.Comment
                                });
                            }

                            cachedValue = JsonConvert.SerializeObject(configs);

                            //write to localCache
                            if (_expirationSeconds.HasValue)
                                _localCache.Set(key, cachedValue, new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_expirationSeconds.Value) });
                            else
                                _localCache.Set(key, cachedValue);
                        }
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }

            return cachedValue;
        }

        private class TenantConfigDto
        {
            public int TenantId { get; set; }
            public string ConfigType { get; set; }
            public string ConfigName { get; set; }
            public string Version { get; set; }
            public string Value { get; set; }
            public string Comment { get; set; }
        }
    }
}
