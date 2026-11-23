using Notification.CoreInterface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class CarrefourCbonNotification : BasicNotification<CarrefourCbonRequestDto, CarrefourCbonResponseDto>
    {

        public override string DoNotify(CarrefourCbonRequestDto request, out string response)
        {
            response = string.Empty;

            if (string.IsNullOrEmpty(extensionData[CommonConsts.Address]))
            {
                response = InternalConsts.InvalidUrl;
                return ResponseCodes.Failed;
            }

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (var client = new HttpClient())
                {
                    //request.VoucherNo = DesHelper.Encrypt(request.VoucherNo, extensionData[CommonConsts.SecurityKey]);

                    var data = string.Concat(request.VoucherNo,
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
                        extensionData[CommonConsts.SecurityKey]);

                    request.CheckSum = CalculateHash(data);

                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], request).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;
                    //    var responseDto = new JavaScriptSerializer().Deserialize<CarrefourCbonResponseDto>(rawJson);

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
