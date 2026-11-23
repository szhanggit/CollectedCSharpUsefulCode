using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFileEx0
{
    public static class Helper
    {
        public static string ReadFile(string configLocation)
        {
            string content = null;

            using (StreamReader sr = new StreamReader(configLocation))
            {
                content = sr.ReadToEnd();
            }

            return content;
        }
    }
}
