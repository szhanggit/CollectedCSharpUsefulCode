using Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantConfigController : ApiBaseController
    {
        public TenantConfigController(IMediator mediator) : base(mediator)
        {

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<TenantConfigDto>> Get(int tenantId, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllTenantConfigQuery() { TenantId = tenantId }, cancellationToken);
            return result.Data;
        }
    }
}
