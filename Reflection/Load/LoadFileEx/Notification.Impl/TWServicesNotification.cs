using Notification.CoreInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class TWServicesNotification : BasicNotification<TWServicesRequestDto, TWServicesResponseDto>
    {
        //private ILog logger = LogManager.GetLogger(typeof(TWServicesNotification));
        public override string DoNotify(TWServicesRequestDto request, out string response)
        {
            response = string.Empty;

            if (string.IsNullOrEmpty(extensionData[CommonConsts.Address]))
            {
                response = InternalConsts.InvalidUrl;
                return ResponseCodes.Failed;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    //request.VoucherNo = DesHelper.Encrypt(request.VoucherNo, request.SecurityKey);

                    var data = string.Concat(
                        request.ClientCode,
                        EQUALS,
                        request.SecurityKey,
                        EQUALS,
                        request.VoucherNo,
                        EQUALS,
                        request.ProgramCode,
                        EQUALS,
                        request.Status.ToString(),
                        EQUALS,
                        request.ActionDate,
                        EQUALS,
                        request.MerchantCode,
                        EQUALS,
                        request.MerchantName,
                        EQUALS,
                        request.ShopCode,
                        EQUALS,
                        request.ShopName,
                        EQUALS,
                        request.SecurityKey);

                    request.CheckSum = CalculateHash(data);

                    string authorizationHeader = ConfigurationManager.AppSettings["TWServicesAuthorizationHeader"].ToString();
                    client.DefaultRequestHeaders.Add("Authorization", authorizationHeader);

                    TWServicesDto postValue = request;

                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], postValue).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;

                    //    logger.InfoFormat("[ChinaTrustNotification] Response Json:{0}", rawJson);

                    //    var responseDto = new JavaScriptSerializer().Deserialize<TWServicesResponseDto>(rawJson);

                    //    if (responseDto == null || responseDto.ResponseCode != ResponseCodes.Success)
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
