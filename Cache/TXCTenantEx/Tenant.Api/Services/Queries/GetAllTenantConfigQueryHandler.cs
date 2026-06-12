using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;

namespace Services.Queries
{
    public class GetAllTenantConfigQueryHandler : IRequestHandlerWrapper<GetAllTenantConfigQuery, IEnumerable<TenantConfigDto>>
    {
        //private readonly IMapper _mapper;
        //private readonly GetTenantConfigService _getTenantConfigService;
        //public GetAllTenantConfigQueryHandler(IMapper mapper,
        //    GetTenantConfigService getTenantConfigService)
        //{
        //    _mapper = mapper;
        //    _getTenantConfigService = getTenantConfigService;
        //}

        public GetAllTenantConfigQueryHandler()
        {

        }

        public async Task<Response<IEnumerable<TenantConfigDto>>> Handle(GetAllTenantConfigQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //var grpcRequest = _mapper.Map<GetTenantConfigRequest>(request);
                //var grpcResponse = await _getTenantConfigService.GetTenantConfig(grpcRequest);

                //if (grpcResponse.Success)
                //    return Response.Success("Success", grpcResponse.Data == null ? null : _mapper.Map<IEnumerable<TenantConfigDto>>(grpcResponse.Data.Unpack<GetTenantConfigResponse>().TenantConfigItems));
                return Response.Fail<IEnumerable<TenantConfigDto>>("Not found", null);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
