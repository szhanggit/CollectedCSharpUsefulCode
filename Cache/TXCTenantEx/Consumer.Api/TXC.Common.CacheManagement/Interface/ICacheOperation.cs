using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TXC.Common.CacheManagement.Interface
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
}
