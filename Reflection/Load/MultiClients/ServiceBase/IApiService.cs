using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBase
{
    public interface IApiService
    {
        void Do(string _accountName, string _accountPwd, string _url);
    }
}
