using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSectionEx2
{
    class Program
    {
        public static void GetConfigurationUsingSectionGroup()
        {
            var PostSetting = ConfigurationManager.GetSection("BlogGroup/PostSetting") as NameValueCollection;
            if (PostSetting.Count == 0)
            {
                Console.WriteLine("Post Settings are not defined");
            }
            else
            {
                foreach (var key in PostSetting.AllKeys)
                {
                    Console.WriteLine(key + " = " + PostSetting[key]);
                }
            }
        }

        static void Main(string[] args)
        {
            GetConfigurationUsingSectionGroup();
            Console.ReadKey();
        }
    }
}
