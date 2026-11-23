using ServiceBase;
using StudentClientLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IApiService scs = new StudentClientService();
            scs.Do("stzhang", "WelcomeMar2021", "http://localhost:59184/api/");
        }
    }
}
