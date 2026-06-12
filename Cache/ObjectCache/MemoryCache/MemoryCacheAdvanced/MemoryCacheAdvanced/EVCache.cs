using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace MemoryCacheAdvanced
{
    public class EVCache
    {
        private ObjectCache objectCache;
        private static readonly EVCache instance = new EVCache();

        public int DefaultCacheDuration { get; set; }

        static EVCache()
        {
        }

        private EVCache()
        {
            objectCache = MemoryCache.Default;
            DefaultCacheDuration = 60 * 30;
        }

        public static EVCache Instance
        {
            get
            {
                return instance;
            }
        }

        private DateTimeOffset GetDefaultExpiryDateTime()
        {
            return DateTimeOffset.Now.AddSeconds(DefaultCacheDuration);
        }

        private void ValidateKey(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentOutOfRangeException("key", "Cache keys cannot be empty or whitespace");
        }

        //https://www.dotnetperls.com/lazy
        private static T UnwrapLazy<T>(object item)
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

        public void Add<T>(string key, T item)
        {
            Add(key, item, GetDefaultExpiryDateTime());
        }

        public void Add<T>(string key, T item, DateTimeOffset expires)
        {
            Add(key, item, new CacheItemPolicy { AbsoluteExpiration = expires });
        }

        public void Add<T>(string key, T item, TimeSpan slidingExpiration)
        {
            Add(key, item, new CacheItemPolicy { SlidingExpiration = slidingExpiration });
        }

        private void Add<T>(string key, T item, CacheItemPolicy policy)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item, key: " + key);
            }
            ValidateKey(key);

            if (item != null)
            {
                objectCache.Set(key, item, policy);
            }
        }

        public T Get<T>(string key)
        {
            ValidateKey(key);

            var item = objectCache[key];
            return UnwrapLazy<T>(item);
        }

        public T GetOrAdd<T>(string key, Func<T> addItemFactory)
        {
            return GetOrAdd(key, addItemFactory, GetDefaultExpiryDateTime());
        }

        public T GetOrAdd<T>(string key, Func<T> addItemFactory, DateTimeOffset expires)
        {
            return GetOrAdd(key, addItemFactory, new CacheItemPolicy { AbsoluteExpiration = expires });
        }

        public T GetOrAdd<T>(string key, Func<T> addItemFactory, TimeSpan slidingExpiration)
        {
            return GetOrAdd(key, addItemFactory, new CacheItemPolicy { SlidingExpiration = slidingExpiration });
        }

        private T GetOrAdd<T>(string key, Func<T> addItemFactory, CacheItemPolicy policy)
        {
            ValidateKey(key);

            var newLazyCacheItem = new Lazy<T>(addItemFactory);
            //Ensure Removed Callback Does Not Return The Lazy
            var existingCacheItem = objectCache.AddOrGetExisting(key, newLazyCacheItem, policy);
            if (existingCacheItem != null)
            {
                return UnwrapLazy<T>(existingCacheItem);
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

        public void Remove(string key)
        {
            ValidateKey(key);
            objectCache.Remove(key);
        }
    }
}
