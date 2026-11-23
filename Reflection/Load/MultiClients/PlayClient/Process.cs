using CommonLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlayClient
{
    public class Process
    {
        public void Do(string AccountName, string AccountPwd, string url)
        {
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
                var postTask = client.PostAsync("Play", data);
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
