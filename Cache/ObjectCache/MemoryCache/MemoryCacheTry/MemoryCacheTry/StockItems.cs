using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCacheTry
{
    public class StockItems
    {
        private const string CacheKey = "availableStocks";
        private const int DefaultCacheDuration = 60 * 30;

        public IEnumerable GetAvailableStocks()
        {
            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(CacheKey))
                return (IEnumerable)cache.Get(CacheKey);
            else
            {
                IEnumerable availableStocks = this.GetDefaultStocks();

                // Store data in the cache    
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(CacheKey, availableStocks, cacheItemPolicy);

                return availableStocks;
            }
        }

        public IEnumerable AddOrGetAvailableStocks(string key)
        {
            Func<IEnumerable> stocks = GetAvailableStocks;
            ObjectCache objectCache = MemoryCache.Default;
            var newLazyCacheItem = new Lazy<IEnumerable>(stocks);
            var policy = new CacheItemPolicy { AbsoluteExpiration = GetDefaultExpiryDateTime() };
            var existingCacheItem = objectCache.AddOrGetExisting(key, newLazyCacheItem, policy);
            if (existingCacheItem != null)
            {
                return UnwrapLazy<IEnumerable>(existingCacheItem);
            }

            try
            {
                var ret = newLazyCacheItem.Value;
                if (ret == null)
                {
                    objectCache.Remove(key);
                }
                return ret;
            }
            catch //addItemFactory errored so do not cache the exception
            {
                objectCache.Remove(key);
                throw;
            }
        }

        public IEnumerable GetDefaultStocks()
        {
            return new List<string>() { "Pen", "Pencil", "Eraser" };
        }

        private DateTimeOffset GetDefaultExpiryDateTime()
        {
            return DateTimeOffset.Now.AddSeconds(DefaultCacheDuration);
        }

        private T UnwrapLazy<T>(object item)
        {
            var lazy = item as Lazy<T>;
            if (lazy != null)
            {
                return lazy.Value;
            }

            if (item is T)
            {
                return (T)item;
            }

            return default(T);
        }
    }
}
