using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXC.Common.CacheManagement.Models
{
    public class RedisConfiguration
    {
        public string ConnectionString { get; set; }
        public string InstanceName { get; set; }
    }
}
