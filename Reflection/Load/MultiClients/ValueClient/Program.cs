using ServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueClientLib;

namespace ValueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IApiService vcs = new ValueClientService();
            vcs.Do("stzhang", "WelcomeMar2021", "http://localhost:59184/api/");
        }
    }
}
