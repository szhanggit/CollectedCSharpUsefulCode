using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public class VoucherInfo
    {
        public VoucherInfo()
        {

        }

        public string OrderNumber { get; set; }
        public int orderlineId { get; set; }
        public string VoucherNumber { get; set; }
        public int OrderBeneficiaryInfoId { get; set; }
        public string Email { get; set; }
        public string ClientName { get; set; }
        public string ProductCode { get; set; }
    }
}
