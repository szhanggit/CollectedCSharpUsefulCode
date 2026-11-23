using CommonLib;
using Newtonsoft.Json;
using ServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentClientLib
{
    [Serializable]
    public class StudentClientService : SBase, IApiService
    {
        public void Do(string _accountName, string _accountPwd, string _url)
        {
            AccountName = _accountName;
            AccountPwd = _accountPwd;
            url = _url;

            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = AccountName,
                AccountPwd = AccountPwd
            };

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var postTask = client.PostAsync("Student", data);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    AccountInfoResponse response = JsonHelper.FromJson<AccountInfoResponse>(readTask.Result);
                    readTask.Wait();
                }
            }
        }
    }
}
