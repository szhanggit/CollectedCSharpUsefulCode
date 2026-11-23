using Notification.CoreInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class MWVNotification : BasicNotification<MWVRequestDto, MWVResponseDto>
    {
        //private ILog logger = LogManager.GetLogger(typeof(MWVNotification));
        public override string DoNotify(MWVRequestDto request, out string response)
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
                    //request.VoucherNo = DesHelper.Encrypt(request.VoucherNo, extensionData[CommonConsts.SecurityKey]);
                    var data = string.Concat(
                        request.TranCode,
                        EQUALS,
                        request.VoucherGUID,
                        EQUALS,
                        request.VoucherNo,
                        EQUALS,
                        request.ProgramCode,
                        EQUALS,
                        request.Status.ToString(),
                        EQUALS,
                        request.ActionDate,
                        EQUALS,
                        request.TranType,
                        EQUALS,
                        request.ProductType,
                        EQUALS,
                        request.TranAmount,
                        EQUALS,
                        request.BalanceAvailable,
                        EQUALS,
                        request.ShopCode,
                        EQUALS,
                        request.ShopName);

                    request.CheckSum = CalculateHash(data);

                    //string authorizationHeader = ConfigurationManager.AppSettings["TWServicesAuthorizationHeader"].ToString();
                    //client.DefaultRequestHeaders.Add("Authorization", authorizationHeader);

                    //TWServicesDto postValue = request;

                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], request).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;

                    //    logger.InfoFormat("[MWVNotification] Response Json:{0}", rawJson);

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
