using Notification.CoreInterface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    public abstract class BasicNotification<RQ, RS> : INotification<RQ, string>
        where RQ : BasicRequestDto
        where RS : BasicResponseDto
    {
        protected IDictionary<string, string> extensionData = new Dictionary<string, string>();
        protected const string EQUALS = "=";

        public virtual IDictionary<string, string> ExtensionData
        {
            get
            {
                return extensionData;
            }
        }

        public virtual bool ValidateParams(RQ request, out string errors)
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
            else if (!Enum.IsDefined(typeof(VoucherStatus), request.Status))
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

        public virtual string DoNotify(RQ request, out string response)
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

                    //using (var responseMessage = client.PostAsJsonAsync(extensionData[CommonConsts.Address], request).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;
                    //    var responseDto = new JavaScriptSerializer().Deserialize<RS>(rawJson);

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

        protected string CalculateHash(string data, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var buffer = new MD5CryptoServiceProvider().ComputeHash(encoding.GetBytes(data));
            var sb = new StringBuilder();
            foreach (var b in buffer)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

    }
}
