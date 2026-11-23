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
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
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

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
