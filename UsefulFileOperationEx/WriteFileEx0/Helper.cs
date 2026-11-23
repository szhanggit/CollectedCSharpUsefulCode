using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteFileEx0
{
    public static class Helper
    {
        public static void WriteFile(string configLocation, string content)
        {
            using (StreamWriter outfile = new StreamWriter(configLocation))
            {
                outfile.Write(content);
            }
        }
    }
}
