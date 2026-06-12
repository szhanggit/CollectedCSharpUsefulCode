using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly IMediator mediator;
        public ApiBaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
