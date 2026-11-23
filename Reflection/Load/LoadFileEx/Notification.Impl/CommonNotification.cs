using Notification.CoreInterface;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class CommonNotification : BasicNotification<CommonRequestDto, CommonResponseDto>
    {
        //private ILog logger = LogManager.GetLogger(typeof(CommonNotification));
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

                    //    logger.InfoFormat("[CommonNotification] Response Json:{0}", rawJson);

                    //    var responseDto = new JavaScriptSerializer().Deserialize<CommonResponseDto>(rawJson);

                    //    if (responseDto == null || responseDto.returnCode != ResponseCodes.Success)
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
