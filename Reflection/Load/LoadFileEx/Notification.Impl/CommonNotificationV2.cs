using Notification.CoreInterface;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class CommonNotificationV2 : BasicNotification<CommonRequestDto, CommonResponseV2Dto>
    {
        //private ILog logger = LogManager.GetLogger(typeof(CommonNotificationV2));
        public override string DoNotify(CommonRequestDto request, out string response)
        {
            response = string.Empty;

            if (string.IsNullOrEmpty(extensionData[CommonConsts.Address]))
            {
                response = InternalConsts.InvalidUrl;
                return ResponseCodes.Failed;
            }

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                using (var client = new HttpClient())
                {
                    const int AESkeyLength = 32;
                    if (extensionData[CommonConsts.SecurityKey].Trim().Length == AESkeyLength)
                    {
                        //request.VoucherNo = AESHelper.Encrypt(request.VoucherNo, extensionData[CommonConsts.SecurityKey]);
                    }
                    else
                    {
                        //request.VoucherNo = DesHelper.Encrypt(request.VoucherNo, extensionData[CommonConsts.SecurityKey]);
                    }

                    var data = string.Concat(request.VoucherNo,
                        EQUALS,
                        request.ProgramCode,
                        EQUALS,
                        request.Status.ToString(),
                        EQUALS,
                        request.ActionDate,
                        EQUALS,
                        extensionData[CommonConsts.SecurityKey]);

                    request.CheckSum = CalculateHash(data);

                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], request).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;

                    //    logger.InfoFormat("[CommonNotificationV2] Response Json:{0}", rawJson);

                    //    var responseV2Dto = new JavaScriptSerializer().Deserialize<CommonResponseV2Dto>(rawJson);

                    //    if (responseV2Dto == null || (!responseV2Dto.success && string.IsNullOrEmpty(responseV2Dto.returnCode))
                    //        || (!string.IsNullOrEmpty(responseV2Dto.returnCode) && responseV2Dto.returnCode != ResponseCodes.Success))
                    //    {
                    //        response = rawJson;
                    //        return ResponseCodes.Failed;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                response = ex.Message + ex.StackTrace;
                return ResponseCodes.Failed;
            }

            return ResponseCodes.Success;
        }
    }
}
