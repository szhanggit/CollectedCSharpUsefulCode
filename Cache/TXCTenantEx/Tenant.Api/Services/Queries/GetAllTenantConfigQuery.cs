using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXC.Common.Services.Wrappers;

namespace Services.Queries
{
    public class GetAllTenantConfigQuery : IRequestWrapper<IEnumerable<TenantConfigDto>>
    {
        public int TenantId { get; set; }
    }
}
