using eVoucher.Distribution.Common;
using InfobipEmailTreepay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            InfobipEmailService sbs = new InfobipEmailService();
            ThirdPartyResult ret = sbs.SendMail("steven.zhang@edenred.com", "Steven Zhang", "Yiding Zhang", string.Empty, string.Empty, "Test", "Test Body", string.Empty, string.Empty);

            if (ret.IsSuccess)
            {
                //var result = sbs.TrackMail(ret.SPId);

                //var thirdPartyResult = (ThirdPartyResult)result;
                //if (thirdPartyResult.IsSuccess)
                //{
                //    JObject obj = JObject.Parse(thirdPartyResult.ExtensionInfo);
                //    int count = obj["data"].Count();
                //    for (int j = 0; j < count; j++)
                //    {
                //        int status = 4;
                //        string eventString = obj["data"][j]["event"].ToString();
                //        if (eventString == "delivery")
                //        {
                //            status = 3;
                //        }
                //    }
                //}

                //string abc = result.SPStatus;
            }
        }
    }
}
