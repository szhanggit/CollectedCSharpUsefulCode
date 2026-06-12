using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TXC.Common.CacheManagement.Interface;

namespace TXC.Common.CacheManagement.ConfigCollection
{
    public class TenantConfigCacheRead : ITxcCacheRead
    {
        private readonly IMemoryCache _localCache;
        private readonly IDistributedCache _distCache;
        private readonly IHttpClientFactory _httpClientFactory;
        private int? _expirationSeconds = null;
        private string _serviceUri;

        private string configServiceUri = "Cache:TenantConfig:Uri";

        public TenantConfigCacheRead(IMemoryCache localCache, IDistributedCache distCache, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _localCache = localCache;
            _distCache = distCache;
            _httpClientFactory = httpClientFactory;
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
                    var httpClient = _httpClientFactory.CreateClient();

                    try
                    {
                        var finalUri = _serviceUri + "?TenantId=" + tenantId;
                        var httpResponseMessage = await httpClient.GetAsync(finalUri);

                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            cachedValue = await httpResponseMessage.Content.ReadAsStringAsync();

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
    }
}
