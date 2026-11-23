using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class UserRoleResponse
    {
        public int UserRoleValue { get; set; }
        public List<FeatureList> FeatureList { get; set; }
        public List<MerchantInfoByAccount> Merchants { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class FeatureList
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }

    public class MerchantInfoByAccount
    {
        public string MerchantCode { get; set; }
        public string MerchantName { get; set; }

    }
}
