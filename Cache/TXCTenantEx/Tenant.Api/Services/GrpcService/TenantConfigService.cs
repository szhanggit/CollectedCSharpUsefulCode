using Grpc.Core;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXC.Proto.Tenant;

namespace Services.GrpcService
{
    public class TenantConfigService : TenantConfig.TenantConfigBase
    {
        private readonly IGetTenantConfigService _getTenantConfigService;

        public TenantConfigService(IGetTenantConfigService getTenantConfigService)
        {
            _getTenantConfigService = getTenantConfigService;
        }

        public override async Task<ProtoBaseResponse> GetTenantConfig(GetTenantConfigRequest request, ServerCallContext context)
        {
            return await _getTenantConfigService.GetTenantConfig(request);
        }
    }
}
