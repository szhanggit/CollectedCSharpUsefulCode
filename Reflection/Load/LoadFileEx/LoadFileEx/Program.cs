using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadFileEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper.Invoke("ValueClientLib.dll", "ValueClientLib.ValueClientService", "Do", "stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
            //Helper.Invoke("StudentClientLib.dll", "StudentClientLib.StudentClientService", "Do", "stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
            //Helper.Invoke("PlayClientLib.dll", "PlayClientLib.PlayClientService", "Do", "stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
            Helper.Invoke2("ValueClientLib", "ValueClientLib.ValueClientService", "stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
            //Helper.Invoke2("StudentClientLib", "StudentClientLib.StudentClientService", "stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
            //Helper.Invoke2("PlayClientLib", "PlayClientLib.PlayClientService", "stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
            //Helper.Invoke3("ValueClientLib.dll", "ValueClientLib.ValueClientService", "Do", "stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
            //Helper.Invoke4("ValueClientLib.dll", "ValueClientLib.ValueClientService", "Do", "stzhang", "WelcomeMar2021", @"http://localhost:59184/api/");
        }
    }
}
