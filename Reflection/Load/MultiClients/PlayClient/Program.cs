using PlayClientLib;
using ServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IApiService scs = new PlayClientService();
            scs.Do("stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
        }
    }
}
