using Notification.CoreInterface;
using System;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class YuantaBankNotification : BasicNotification<YuantaBankRequestDto, YuantaBankResponseDto>
    {
        //private ILog logger = LogManager.GetLogger(typeof(YuantaBankNotification));
        public override string DoNotify(YuantaBankRequestDto request, out string response)
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

                    var req = new YuantaBankRequestExtendDto()
                    {
                        ProgramCode = request.ProgramCode,
                        VoucherNo = request.VoucherNo,
                        Status = request.Status.ToString(),
                        ActionDate = request.ActionDate,
                        CheckSum = request.CheckSum
                    };


                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], req).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;

                    //    logger.InfoFormat("[YuantaBankNotification] Response Json:{0}", rawJson);

                    //    var responseDto = new JavaScriptSerializer().Deserialize<YuantaBankResponseDto>(rawJson);

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
