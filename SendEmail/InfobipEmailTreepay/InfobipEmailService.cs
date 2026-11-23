using eVoucher.Distribution.Common;
using eVoucher.Distribution.SenderService.Interface;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using System.Linq;

namespace InfobipEmailTreepay
{
    public class InfobipEmailService : IEmailAdapter
    {
        private static readonly INIClass INIObject;

        static InfobipEmailService()
        {
            INIObject = new INIClass(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Adapter.ini"));
        }

        public ThirdPartyResult SendMail(string from, string fromName, string to, string cc, string bcc, string subject, string body, string attachements, string bodyFormat)
        {
            var result = new ThirdPartyResult();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (HttpClient client = new HttpClient())
                {
                    string section = GetType().Namespace;
                    string username = "DEALCHATH";// INIObject.IniReadValue(section, "username");
                    string password = "Dealchathinfo5$";// INIObject.IniReadValue(section, "password");
                    byte[] headers = System.Text.Encoding.ASCII.GetBytes(username + ":" + password);

                    client.BaseAddress = new Uri(@"https://5w8zg.api.infobip.com/");//INIObject.IniReadValue(section, "url")
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(headers));

                    var request = new MultipartFormDataContent();
                    if (string.IsNullOrEmpty(fromName))
                    {
                        request.Add(new StringContent(from), "from");
                    }
                    else
                    {
                        request.Add(new StringContent(string.Format("{0} <{1}>", fromName, from)), "from");
                    }

                    to.Split(new char[] { ';' }).ToList().ForEach(t => request.Add(new StringContent(t), "to"));

                    request.Add(new StringContent(subject), "subject");

                    if ("text".Equals(bodyFormat, StringComparison.InvariantCultureIgnoreCase))
                    {
                        request.Add(new StringContent(body), "text");
                    }
                    else
                    {
                        request.Add(new StringContent(body), "html");
                    }

                    if (!string.IsNullOrEmpty(attachements))
                    {
                        attachements.Split(new char[] { ';' }).ToList().ForEach(t => request.Add(new StreamContent(File.OpenRead(t)), "attachment", Path.GetFileName(t)));
                    }

                    var response = client.PostAsync("email/1/send", request).Result;
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        dynamic responseObj = new JavaScriptSerializer().Deserialize<dynamic>(responseString);

                        result.IsSuccess = true;

                        string linkString = ",";
                        foreach (var item in responseObj["messages"])
                        {
                            if (result.IsSuccess == true)
                            {
                                InfobipSendStatus status = (InfobipSendStatus)Convert.ToInt32(item["status"]["groupId"]);
                                result.IsSuccess = (status == InfobipSendStatus.PENDING || status == InfobipSendStatus.DELIVERED);
                            }

                            result.SPId += item["messageId"] + linkString;

                            result.ExtensionInfo += (item["messageId"] + ":" + item["status"]["name"] + ":" + item["status"]["description"] + " ");
                        }
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.SPId = null;
                        if (responseString.Length > 500)
                            result.ExtensionInfo = responseString.Substring(0, 500);
                        else
                            result.ExtensionInfo = responseString;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.SPId = null;
                result.ExtensionInfo = ex.Message + ex.StackTrace;
            }

            return result;
        }

        public ThirdPartyResult TrackMail(string code)
        {
            var result = new ThirdPartyResult();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (HttpClient client = new HttpClient())
                {
                    string section = GetType().Namespace;
                    string username = INIObject.IniReadValue(section, "username");
                    string password = INIObject.IniReadValue(section, "password");
                    byte[] headers = System.Text.Encoding.ASCII.GetBytes(username + ":" + password);

                    client.BaseAddress = new Uri(INIObject.IniReadValue(section, "url"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(headers));

                    //reports 只能查询一次，以后返回null
                    //logs 只能查询48小时内的
                    //var response = client.GetAsync("email/1/reports?messageId=" + code).Result;
                    var response = client.GetAsync("email/1/logs?messageId=" + code).Result;
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        dynamic responseObj = new JavaScriptSerializer().Deserialize<dynamic>(responseString);

                        result.IsSuccess = true;
                        result.SPId = code;

                        foreach (var item in responseObj["results"])
                        {
                            if (result.IsSuccess == true)
                            {
                                InfobipSendStatus status = (InfobipSendStatus)Convert.ToInt32(item["status"]["groupId"]);
                                result.IsSuccess = (status == InfobipSendStatus.DELIVERED);
                            }

                            result.ExtensionInfo += (item["messageId"] + ":" + item["status"]["name"] + ":" + item["status"]["description"] + " ");
                        }
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.SPId = code;
                        if (responseString.Length > 500)
                            result.ExtensionInfo = responseString.Substring(0, 500);
                        else
                            result.ExtensionInfo = responseString;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.SPId = code;
                result.ExtensionInfo = ex.Message + ex.StackTrace;
            }

            return result;
        }
    }

    public enum InfobipSendStatus
    {
        PENDING = 1,
        UNDELIVERABLE = 2,
        DELIVERED = 3,
        EXPIRED = 4,
        REJECTED = 5
    }
}
