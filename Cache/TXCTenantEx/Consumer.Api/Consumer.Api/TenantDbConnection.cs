using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TXC.Common.CacheManagement.ConfigCollection;
using TXC.Common.CacheManagement.GrpcServices;
using TXC.Common.CacheManagement.Interface;
using TXC.Common.Domain;
using System.Data.SqlClient;

namespace Consumer.Api
{
    public interface ITenantDbConnection
    {
        Task<Response<IDbConnection>> GetTenantDbConnection(string tenantId, bool isReadReplica, CancellationToken cancellationToken);
        Task<Response<IDbConnection>> GetTenantDbConnection(bool isReadReplica, CancellationToken cancellationToken);
    }
    public class TenantDbConnection : ITenantDbConnection, IDisposable
    {
        private readonly IServiceProvider _provider;
        private string _tenantId;
        // scoped instance
        private IDbConnection existingConnection = null;
        public TenantDbConnection(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<Response<IDbConnection>> GetTenantDbConnection(string tenantId, bool isReadReplica, CancellationToken cancellationToken)
        {
            _tenantId = tenantId;
            return await GetTenantDbConnection(isReadReplica, cancellationToken);
        }

        public async Task<Response<IDbConnection>> GetTenantDbConnection(bool isReadReplica, CancellationToken cancellationToken)
        {
            string credentialConnString = "";

            //check tx2 connector config
            //ITxcCacheRead tenantConfigCache = this._provider.GetService<TenantConfigCacheRead>();
            ITxcCacheRead tenantConfigCache = this._provider.GetService<GrpcTenantConfigCacheRead>();

            // check if override connection to connect directly to DB (not use sharding)
            // use tenantconfig for it
            var tenantConfigStr = await tenantConfigCache.GetAsync(new System.Collections.Generic.Dictionary<string, string>() { { "TenantId", _tenantId } });
            if (!string.IsNullOrEmpty(tenantConfigStr))
            {
                var tenantConfigs = JsonConvert.DeserializeObject<IEnumerable<TenantConfig>>(tenantConfigStr);
                TenantConfig overrideConfig = tenantConfigs.FirstOrDefault(t => t.ConfigName.Equals("OverrideTenantDbConnection"));

                if (overrideConfig != null)
                {

                }
            }

            existingConnection = new SqlConnection(credentialConnString);
            return Response.Success("Success", existingConnection);
        }

        public void Dispose()
        {
            if (existingConnection != null)
                existingConnection.Dispose();
        }
    }
}
