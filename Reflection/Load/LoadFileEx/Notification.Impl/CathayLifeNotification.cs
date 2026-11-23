using Notification.CoreInterface;
using System;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class CathayLifeNotification : BasicNotification<CathayLifeRequestDto, CathayLifeResponseDto>
    {
        //private ILog logger = LogManager.GetLogger(typeof(CathayLifeNotification));
        //public override string DoNotify(CathayLifeRequestDto request, out string response)
        //{
        //    response = string.Empty;

        //    if (string.IsNullOrEmpty(extensionData[CommonConsts.Address]))
        //    {
        //        response = InternalConsts.InvalidUrl;
        //        return ResponseCodes.Failed;
        //    }

        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            request.VoucherNo = DesHelper.Encrypt(request.VoucherNo, extensionData[CommonConsts.SecurityKey]);

        //            var data = string.Concat(request.VoucherNo,
        //                EQUALS,
        //                request.ProgramCode,
        //                EQUALS,
        //                request.Status.ToString(),
        //                EQUALS,
        //                request.ActionDate,
        //                EQUALS,
        //                request.ShopCode,
        //                EQUALS,
        //                request.ShopName,
        //                EQUALS,
        //                extensionData[CommonConsts.SecurityKey]);

        //            request.CheckSum = CalculateHash(data);

        //            using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], request).Result)
        //            {
        //                var rawJson = responseMessage.Content.ReadAsStringAsync().Result;
        //                var responseDto = new JavaScriptSerializer().Deserialize<CathayLifeResponseDto>(rawJson);

        //                logger.InfoFormat("[CathayLifeNotification] Response Json:{0}", rawJson);

        //                if (responseDto == null || responseDto.returnCode != ResponseCodes.Success)
        //                {
        //                    response = responseDto.returnMessage;
        //                    return ResponseCodes.Failed;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = ex.Message + ex.StackTrace;
        //        return ResponseCodes.Failed;
        //    }

        //    return ResponseCodes.Success;
        //}


        public override string DoNotify(CathayLifeRequestDto request, out string response)
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

                    request.CheckSum = CalculateHash(data);

                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], new { request.VoucherNo, request.ActionDate, request.CheckSum, request.ProgramCode, request.Status }).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;
                    //    var responseDto = new JavaScriptSerializer().Deserialize<CathayLifeResponseDto>(rawJson);

                    //    logger.InfoFormat("[CathayLifeNotification] Response Json:{0}", rawJson);

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
