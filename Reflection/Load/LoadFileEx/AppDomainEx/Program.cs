using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainEx
{
    [Serializable]
    public class MyClass
    {
        public string HomeAppDomain
        {
            get
            {
                return AppDomain.CurrentDomain.FriendlyName;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AppDomain newDomain = AppDomain.CreateDomain("My New AppDomain");

            MyClass mbvObject = (MyClass)newDomain.CreateInstanceFromAndUnwrap(
                    "AppDomainEx.exe",
                    "AppDomainEx.MyClass");

            Console.WriteLine("AppDomain of MBV object = {0}", mbvObject.HomeAppDomain);
        }
    }
}
