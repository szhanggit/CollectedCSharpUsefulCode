using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DistributedCacheEx
{
    public interface ICacheOperation
    {
        public Task<T> GetCacheAsync<T>(string key, CancellationToken cancellationToken);
        public Task SetCacheAsync<T>(string key,
            T data,
            CancellationToken cancellationToken,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null);
        public T GetCache<T>(string key);
        public void SetCache<T>(string key,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null);
        public Task Remove(string key, CancellationToken cancellationToken);
        public Task RemoveAsync(string key, CancellationToken cancellationToken);

    }
    public class CacheOperation : ICacheOperation
    {
        private readonly IDistributedCache _cache;

        public CacheOperation(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T GetCache<T>(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                {
                    //todd : consider changing return non nullable type
                    return default(T);
                }

                var jsonData = _cache.GetString(key);

                if (jsonData is null)
                {
                    return default(T);
                }

                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            catch (Exception)
            {

                return default(T);
            }
        }
        public async Task<T> GetCacheAsync<T>(string key, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                {
                    //todd : consider changing return non nullable type
                    return default(T);
                }

                var jsonData = await _cache.GetStringAsync(key, cancellationToken);

                if (jsonData is null)
                {
                    return default(T);
                }

                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            catch (Exception)
            {

                return default(T);
            }
        }
        public void SetCache<T>(string key, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                {
                    return;
                }

                var options = new DistributedCacheEntryOptions();

                options.AbsoluteExpirationRelativeToNow = absoluteExpireTime;
                options.SlidingExpiration = unusedExpireTime;

                var jsonData = JsonConvert.SerializeObject(data);
                _cache.SetString(key, jsonData, options);
            }
            catch (Exception)
            {

                return;
            }
        }
        public async Task SetCacheAsync<T>(string key, T data, CancellationToken cancellationToken, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null)
        {

            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                {
                    return;
                }

                var options = new DistributedCacheEntryOptions();

                options.AbsoluteExpirationRelativeToNow = absoluteExpireTime;
                options.SlidingExpiration = unusedExpireTime;

                var jsonData = JsonConvert.SerializeObject(data);
                await _cache.SetStringAsync(key, jsonData, options, cancellationToken);
            }
            catch (Exception)
            {

                return;
            }


        }

        public async Task Remove(string key, CancellationToken cancellationToken)
        {

            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                {
                    return;
                }

                await _cache.RemoveAsync(key, cancellationToken);
            }
            catch (Exception)
            {
                return;
            }
        }
        public async Task RemoveAsync(string key, CancellationToken cancellationToken)
        {

            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                {
                    return;
                }

                await _cache.RemoveAsync(key, cancellationToken);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
