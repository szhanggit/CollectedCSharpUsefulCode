using Notification.CoreInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class OCBCGiftPackNotification : BasicNotification<OCBCGiftPackRequestDto, OCBCGiftPackResponseDto>
    {
        //private ILog logger = LogManager.GetLogger(typeof(OCBCGiftPackNotification));
        public override string DoNotify(OCBCGiftPackRequestDto request, out string response)
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
                    var data = string.Concat(request.VoucherNo,
                        EQUALS,
                        request.ProgramCode,
                        EQUALS,
                        request.Status.ToString(),
                        EQUALS,
                        request.ActionDate,
                        EQUALS,
                        extensionData[CommonConsts.SecurityKey]);

                    //... get only few checksum fields because of the old implementation
                    request.CheckSum = CalculateHash(data);

                    //... used for tesing
                    //var rawJson = "{\"returnCode\":\"0000\",\"returnMessage\":\"Success\"}";  //Sample success return code
                    //var responseDto = new JavaScriptSerializer().Deserialize<OCBCGiftPackResponseDto>(rawJson);
                    //if (responseDto == null || responseDto.returnCode != ResponseCodes.Success)
                    //{
                    //    response = responseDto.returnMessage;
                    //    return ResponseCodes.Failed;
                    //}
                    //return ResponseCodes.Success;

                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], request).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;

                    //    logger.InfoFormat("[OCBCNotification] Response Json:{0}", rawJson);

                    //    var responseDto = new JavaScriptSerializer().Deserialize<OCBCGiftPackResponseDto>(rawJson);

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
