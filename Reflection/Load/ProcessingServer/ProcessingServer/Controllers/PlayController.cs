using ProcessingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProcessingServer.Controllers
{
    public class PlayController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(MPSAccountRequest accountInfo)
        {
            try
            {
                //_logger.Info(accountInfo == null ? string.Empty : JsonConvert.SerializeObject(accountInfo));

                var response = new MPSAccountInfoResponse()
                {
                    IsSuccess = true,
                    ErrorMsg = "Everything is good",
                    UserRoleValue = 2,
                    FeatureList = new List<AccountRoleViewModel> {
                        new AccountRoleViewModel{ Id= 2, RoleName = "Admin", RoleValue = 3 }
                    },
                    Merchants = new List<ShopAccountByMerchantViewModel> {
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000023", MerchantName = "McDonald" },
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000024", MerchantName = "KFC" },
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000025", MerchantName = "BubbleTea" },
                    }
                };

                //_logger.Info(response == null ? string.Empty : JsonConvert.SerializeObject(response));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
