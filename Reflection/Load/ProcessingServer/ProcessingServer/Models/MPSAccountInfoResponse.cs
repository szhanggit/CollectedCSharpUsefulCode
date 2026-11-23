using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessingServer.Models
{
    public class MPSAccountInfoResponse : CheckAccountExistsViewModel
    {
        public int UserRoleValue { get; set; }
        public List<AccountRoleViewModel> FeatureList { get; set; }
        public List<ShopAccountByMerchantViewModel> Merchants { get; set; }
    }
}