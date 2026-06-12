using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXC.Common.CacheManagement
{
    public static class TxcCacheKeyGenerator
    {
        public static string ProgramCodeProgramCollection()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Production"))
                return $"ProgramCollection:All";
            else
                return $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}:ProgramCollection:All";
        }
        public static string TenantConfigProgramCollection(int tenantId)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Production"))
                return $"TenantConfig:{tenantId}";
            else
                return $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}:TenantConfig:{tenantId}";
        }
    }
}
