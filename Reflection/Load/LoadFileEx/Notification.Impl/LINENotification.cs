using Notification.CoreInterface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public class LINENotification : INotification<LINERequestDto, string>
    {
        //private ILog logger = LogManager.GetLogger(typeof(TWServicesNotification));

        private IDictionary<string, string> extensionData = new Dictionary<string, string>();

        public IDictionary<string, string> ExtensionData
        {
            get
            {
                return extensionData;
            }
        }

        public bool ValidateParams(LINERequestDto request, out string errors)
        {
            bool result = true;
            errors = string.Empty;

            if (request == null)
            {
                errors = InternalConsts.InvalidRequest;
                result = false;
            }
            else if (string.IsNullOrEmpty(request.ProgramCode))
            {
                errors = InternalConsts.InvalidProgramCode;
                result = false;
            }
            else if (string.IsNullOrEmpty(request.VoucherNo))
            {
                errors = InternalConsts.InvalidVoucherNumber;
                result = false;
            }
            else if (!Enum.IsDefined(typeof(VoucherStatus),request.Status))
            {
                errors = InternalConsts.InvalidVoucherStatus;
                result = false;
            }
            else if (string.IsNullOrEmpty(request.ActionDate))
            {
                errors = InternalConsts.InvalidActionDate;
                result = false;
            }

            return result;
        }

        public string DoNotify(LINERequestDto request, out string response)
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
                    //if (!string.IsNullOrEmpty(request.MasterVoucherNo))
                    //{
                    //    request.MasterVoucherNo = DesHelper.Encrypt(request.MasterVoucherNo, extensionData[CommonConsts.SecurityKey]);
                    //}
                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], request).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;

                    //    logger.InfoFormat("[LINENotification] Response Json:{0}", rawJson);

                    //    var jsonObj = rawJson.Substring(1, rawJson.Length - 2).Replace("\\", string.Empty);
                    //    var lineResponse = new JavaScriptSerializer().Deserialize<LINEResponseDto>(jsonObj);

                    //    if (lineResponse == null || lineResponse.returnCode != ResponseCodes.Success)
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
