using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXC.Common.CacheManagement.Interface
{
    public interface ITxcCacheRead
    {
        public Task<string> GetAsync(Dictionary<string, string> queryParams);
    }
}
