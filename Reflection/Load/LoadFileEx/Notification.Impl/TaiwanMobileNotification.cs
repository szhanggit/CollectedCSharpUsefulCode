using Notification.CoreInterface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class TaiwanMobileNotification : BasicNotification<TaiwanMobileRequestDto, TaiwanMobileResponseDto>
    {
        public override bool ValidateParams(TaiwanMobileRequestDto request, out string errors)
        {
            bool result = true;
            errors = string.Empty;

            result = base.ValidateParams(request, out errors);


            if (request == null)
            {
                errors = InternalConsts.InvalidRequest;
                result = false;
            }
            else if (string.IsNullOrEmpty(request.VoucherGuid))
            {
                errors = InternalConsts.InvalidVoucherGuid;
                result = false;
            }

            return result;
        }

        public override string DoNotify(TaiwanMobileRequestDto request, out string response)
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
                        request.VoucherGuid,
                        EQUALS,
                        extensionData[CommonConsts.SecurityKey]);

                    request.CheckSum = CalculateHash(data);

                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], request).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;
                    //    var responseDto = new JavaScriptSerializer().Deserialize<TaiwanMobileResponseDto>(rawJson);

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
