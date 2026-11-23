using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EnumGetDescription
{
    public static class EnumExtensions
    {
        private static Dictionary<string, string> _LocalStringDictionary;

        public static void ConvertCodeToMessage()
        {
            string languageKey = "CN";

            if (string.IsNullOrEmpty(languageKey))
            {
                languageKey = "EN";
            }

            if (languageKey == "EN")
            {
                _LocalStringDictionary = new Dictionary<string, string>()
                {
                    { "Copyright", "Edenred Pte Ltd." },
                    { "MSP","Uniqgift Merchant Portal"},
                    { "Login","Log in"},
                    { "SignIn","Sign In"},
                    { "SignOut","Sign out"},
                    { "VoucherAction","Transaction"},
                    { "VoucherRedeem","Voucher Redemption"},
                    { "ReverseRedeem","Reverse Redemption"},
                    { "CheckStatus","Check Voucher Status"},
                    { "VoucherReports","Reports"},
                    { "QueryTranHistory","Transaction History"},
                    { "QueryMonthTranHistory","Monthly Transaction History"},
                    { "Select","Please Select"},
                    { "EnterNo","Please enter a voucher number"},
                    { "Cancel","Cancel"},
                    { "Confirm","Confirm"},

                    { "RedeemShop","Redeemed Shop"},
                    { "Redeem","Redeem"},
                    { "TranConfirm","Transaction Confirmation"},
                    { "VoucherNumber","Voucher Number"},
                    { "ProductName","Product Name"},

                    { "TranResult","Transaction Result"},
                    { "Result","Result"},
                    { "Success","Success"},
                    { "Fail","Fail"},
                    { "ShopName","Shop Name"},
                    { "ShopCode","Shop Code"},
                    { "TranTime","Transaction Time"},
                    { "ResponseCode","Response Code"},
                    { "ResponseMessage","Response Message"},
                    { "TranAmount","Transaction Amount"},
                    { "Balance","Balance"},
                    { "EnterAmount","Please enter transaction amount"},

                    { "RedeemFail","Redemption Fail"},
                    { "VoucherStatus","Voucher Status"},
                    { "unKnow","Un Know"},
                    { "Issued","Issued"},
                    { "Active","Active"},
                    { "Expired","Expired"},
                    { "Trashed","Trashed"},
                    { "Blocked","Blocked"},
                    { "Used","Used"},
                    { "InStock","InStock"},
                    { "LastRedeemedShop","Last Redeemed Shop"},
                    { "LastTransactionTime","Last Transaction Time"},
                    { "Close","Close"},

                    { "Reverse","Reverse Redemption"},

                    { "ChooseTran","Please choose a transaction to reverse"},
                    { "ReverseFail","Reverse Redemption Fail"},
                    { "NoTran","There’s no redemption transaction in this shop."},
                    { "ExpiryDate","Expiry Date"},
                    { "TranType","Transaction Type"},
                    { "TranQuantity","Transaction Quantity"},
                    { "Quantity","Quantity"},

                    { "QueryHint","*You can only query the real time reports within 2 days"},
                    { "QueryMonthHint","*This report is Not real time. You can query the data within 1 month, not including Today."},
                    { "StartDate","Start Date"},
                    { "EndDate","End Date"},
                    { "Query","Query"},
                    { "QueryFail","Query Fail"},
                    { "Download","Download"},

                    { "Redemption","Redemption"},
                    { "ReverseRedemption","Reverse Redemption"},

                    { "TP_000","Please fill in this column"},
                    { "TP_001","Please check the voucher number is correct or not"},
                    { "TP_002","Transaction Amount Error"},
                    { "TP_003","Please select a shop to redeem"},
                    { "TP_004","Please enter the voucher number"},
                    { "TP_005","Please confirm again this is the voucher you want to redeem"},
                    { "TP_006","Please choose a transaction to reverse redemption"},
                    { "TP_007","Please select a start date"},
                    { "TP_008","Please select an end date"},
                    { "TP_009","End date cannot earlier then start date"},
                    { "TP_010","Query period cannot more than 1 year"},
                    { "TP_011","No Data"},
                    { "TP_012","System Error"},
                    { "TP_013","Download report error"},
                    { "TP_014","Query period cannot more than 2 days"},
                    { "TP_015","Please select a shop"},
                    { "TP_016","Up to the day before today"},
                    { "TP_017","Query period cannot more than 1 month"},
                    { "TP_018","Up to the day before system date"},
                    { "TP_019","Account Error"},
                    { "TP_020","Please select a value from dropdown list"},

                    { "Item","Item"},
                    { "ProductBase","Product Base"},
                    { "ValueBase","Value Base"},
                    { "SubTotal","Sub Total"},
                    { "Total","Total"},

                    { "ChoseLan","Choose your language"},
                    { "Account","Account"},
                    { "Password","Password"},
                    { "Loading","loading"},
                    { "101","Redemption"},
                    { "201","Reverse Redemption"},
                    { "All","All"},
                    { "Rsv1","Rsv1"},
                    { "TerminalSSN","Terminal SSN"},
                    { "TerminalCode","Terminal Code"},
                    { "Error","Log-in error."},
                    { "ErrorDesc","There was a problem signing in. Please log-in again."},
                    { "RememberMe","Remember Me"},

                    { "Settings","Settings"},
                    { "CSVP","Consumer Scan Validation Password"},
                    { "CSVPDesc","If your Consumer Scan Service is activated, strongly suggest you to setup validation password and change it regularly to avoid fake vouchers. After setup, you can recognize your specific password on the successful page after consumer redeem vouchers by consumer scan camera. If there's no password or it doesn't match to your password, please do not provide merchandise or services to consumers."},
                    { "CSVPSetup","Consumer Scan Validation Password Setup"},
                    { "CurrentPwd","Current Password"},
                    { "ChangePwd","Change Password"},
                    { "CSVPHint","*Your password has to be between 6~16 characters long which support English letters, digit numbers and special characters."},
                    { "CSVPPWDError","Password format has to be between 6~16 characters long and support English letters, digit numbers and special characters."},
                };
            }
            else if (languageKey == "CN")
            {
                _LocalStringDictionary = new Dictionary<string, string>()
                {
                    { "MSP","商家服務平台"},
                    { "Login","商家登入"},
                    { "SignIn","Sign In"},
                    { "SignOut","Sign out"},
                    { "VoucherAction","序號操作"},
                    { "VoucherRedeem","序號核銷"},
                    { "ReverseRedeem","序號取消核銷"},
                    { "CheckStatus","序號查詢"},
                    { "VoucherReports","報表查詢"},
                    { "QueryTranHistory","即時交易紀錄"},
                    { "Select","請選擇"},
                    { "EnterNo","請輸入序號"},
                    { "Cancel","取消"},
                    { "Confirm","確認"},

                    { "RedeemShop","核銷店點"},
                    { "Redeem","序號核銷"},
                    { "TranConfirm","交易確認"},
                    { "VoucherNumber","序號"},
                    { "ProductName","產品名稱"},

                    { "TranResult","交易資訊"},
                    { "Result","結果"},
                    { "Success","交易成功"},
                    { "Fail","交易失敗"},
                    { "ShopName","店點"},
                    { "ShopCode","核銷店號"},
                    { "TranTime","時間"},
                    { "ResponseCode","回應代碼"},
                    { "ResponseMessage","回應訊息"},
                    { "TranAmount","核銷"},
                    { "Balance","餘額"},
                    { "EnterAmount","請輸入交易金額"},

                    { "RedeemFail","核銷失敗"},
                    { "VoucherStatus","序號狀態"},
                    { "unKnow","未知"},
                    { "Issued","已發行"},
                    { "Active","可使用"},
                    { "Expired","已過期"},
                    { "Trashed","已失效"},
                    { "Blocked","已申請退貨"},
                    { "Used","已使用"},
                    { "InStock","庫存"},
                    { "LastRedeemedShop","最後核銷店點"},
                    { "LastTransactionTime","最後核銷時間"},
                    { "Close","Close"},

                    { "Reverse","取消核銷"},

                    { "ChooseTran","請選擇欲取消交易"},
                    { "ReverseFail","取消核銷失敗"},
                    { "NoTran","此分店沒有該筆序號的核銷交易"},
                    { "ExpiryDate","序號效期"},
                    { "TranType","類別"},
                    { "TranQuantity","交易數量"},
                    { "Quantity","剩餘數量"},

                    { "QueryHint","※本交易紀錄為即時，只開放查詢兩天內的交易紀錄"},
                    { "StartDate","開始日期"},
                    { "EndDate","結束日期"},
                    { "Query","查詢"},
                    { "QueryFail","查詢失敗"},
                    { "Download","下載"},

                    { "Redemption","核銷"},
                    { "ReverseRedemption","取消核銷"}
                };
            }
        }

        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            var result = enumerationValue.ToString().ToLocalString();
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }

        public static string ToLocalString(this string key)
        {
            return GetValue(_LocalStringDictionary, key);
        }

        private static string GetValue(Dictionary<string, string> dic, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            if (dic.ContainsKey(key))
            {
                return dic[key];
            }
            return null;
        }
    }
}
