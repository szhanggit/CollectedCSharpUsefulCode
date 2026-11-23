using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public class CheckParaData
    {
        public CheckParaData()
        {

        }

        public int CheckParaId { get; set; }
        public int MessageId { get; set; }
        public int MessageLocalId { get; set; }
        public int Status { get; set; }
        public string MissingTag { get; set; }
        public string MissingVal { get; set; }
        public string OrderNumber { get; set; }
        public int OrderId { get; set; }
        public string VoucherNumber { get; set; }
        public string OrderBeneficiaryInfoId { get; set; }
        public string Email { get; set; }
    }
}
