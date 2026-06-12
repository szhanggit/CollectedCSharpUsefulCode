using Dapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TXC.Common.CacheManagement;
using TXC.Common.Data;
using TXC.Proto.Tenant;

namespace Services.Core
{
    public interface IGetTenantConfigService
    {
        Task<ProtoBaseResponse> GetTenantConfig(GetTenantConfigRequest request);
    }
    public class GetTenantConfigService : IGetTenantConfigService
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDapperOperation _dapperOperation;
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;

        public GetTenantConfigService(IDbConnection dbConnection
            , IDapperOperation dapperOperation
            ,IDistributedCache distributedCache
            , IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _dapperOperation = dapperOperation;
            _distributedCache = distributedCache;
            _configuration = configuration;
        }
        public async Task<ProtoBaseResponse> GetTenantConfig(GetTenantConfigRequest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", request.TenantId, DbType.Int32, ParameterDirection.Input);

                CommandDefinition commandDefinition = new CommandDefinition("sp_sel_all_configs_by_tenant_id", commandType: CommandType.StoredProcedure,
                                                                            parameters: parameters);

                var results = await _dapperOperation.ProcessSql<SelectMany<GetTenantConfigItem>, IEnumerable<GetTenantConfigItem>>(_dbConnection, commandDefinition);

                /*Start: write into distributed cache*/
                int? _expirationSeconds = null;
                var configExp = "Cache:ProgramCollection:ExpirationSeconds";
                if (!string.IsNullOrEmpty(_configuration[configExp]))
                {
                    if (int.TryParse(_configuration[configExp], out int parseResult))
                        _expirationSeconds = parseResult;
                    else
                        throw new Exception($"Unable to parse {configExp}");
                }

                string key = TxcCacheKeyGenerator.TenantConfigProgramCollection(request.TenantId);
                var serialized = JsonConvert.SerializeObject(results);
                if (_expirationSeconds.HasValue)
                    await _distributedCache.SetStringAsync(key, serialized, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_expirationSeconds.Value) });
                else
                    await _distributedCache.SetStringAsync(key, serialized);
                /*End: write into distributed cache*/

                GetTenantConfigResponse response = new GetTenantConfigResponse();
                response.TenantConfigItems.Add(results.ToList());

                if (results != null)
                    return new ProtoBaseResponse
                    {
                        Success = true,
                        Message = "Success",
                        Data = Any.Pack(response)
                    };

                return new ProtoBaseResponse
                {
                    Success = false,
                    Message = "fail",
                    Data = null
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
