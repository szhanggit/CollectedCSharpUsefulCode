using Notification.CoreInterface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace Notification.Impl
{
    internal class NotificationToLine
    {
        public string storeId { get; set; }
        public string status { get; set; }
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string posCode { get; set; }
        public string posDate { get; set; }
    }

    public class LINEB2BNotification : INotification<LINEB2BRequestDto, string>
    {
        private NotificationToLine convert2NotificationToLine(LINEB2BRequestDto internalReq)
        {
            NotificationToLine ret = new NotificationToLine();
            ret.branchCode = internalReq.ShopCode;
            ret.branchName = internalReq.ShopName;
            ret.posCode = internalReq.TerminalCode;
            ret.storeId = internalReq.MerchantCode;
            ret.status = string.Empty;
            if (internalReq.Status == 1)
                ret.status =InternalConsts.LINEB2B_Voucher_Status_Redemption;
            else if (internalReq.Status == 2)
                ret.status = InternalConsts.LINEB2B_Voucher_Status_CancelRedemption;

            ret.posDate = internalReq.ActionDate;

            return ret;
        }

        private IDictionary<string, string> extensionData = new Dictionary<string, string>();

        public IDictionary<string, string> ExtensionData
        {
            get
            {
                return extensionData;
            }
        }

        public bool ValidateParams(LINEB2BRequestDto request, out string errors)
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

        public string DoNotify(LINEB2BRequestDto request, out string response)
        {
            response = string.Empty;

            if (string.IsNullOrEmpty(extensionData[CommonConsts.Address]))
            {
                response = InternalConsts.InvalidUrl;
                return ResponseCodes.Failed;
            }

            if (string.IsNullOrEmpty(extensionData[CommonConsts.LINEB2B_ChannelId]))
            {
                response = InternalConsts.LINEB2B_Invalid_ChannelId;
                return ResponseCodes.Failed;
            }

            if (string.IsNullOrEmpty(extensionData[CommonConsts.LINEB2B_ChannelSecret]))
            {
                response = InternalConsts.LINEB2B_Invalid_ChannelId;
                return ResponseCodes.Failed;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    NotificationToLine notificationToLine = convert2NotificationToLine(request);
                    string address = extensionData[CommonConsts.Address].Replace(InternalConsts.LINEB2B_Voucher_No_PlaceHolder,request.VoucherNo);
                    client.DefaultRequestHeaders.Add(CommonConsts.LINEB2B_ChannelId, extensionData[CommonConsts.LINEB2B_ChannelId]);
                    client.DefaultRequestHeaders.Add(CommonConsts.LINEB2B_ChannelSecret, extensionData[CommonConsts.LINEB2B_ChannelSecret]);
                    //using (var responseMessage = client.PostAsJsonAsync(address, notificationToLine).Result)
                    //{
                    //    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;
                    //    //var jsonObj = rawJson.Substring(1, rawJson.Length - 2).Replace("\\", string.Empty);
                    //    var lineResponse = new JavaScriptSerializer().Deserialize<LINEB2BResponseDto>(rawJson);

                    //    if (lineResponse == null || lineResponse.returnCode != ResponseCodes.LINEB2B_Success)
                    //    {
                    //        response = rawJson; //log to database
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
