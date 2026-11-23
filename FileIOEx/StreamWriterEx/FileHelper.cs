using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriterEx
{
    public static class FileHelper
    {
        public static void WriteFile(string configLocation, string content)
        {
            using (StreamWriter outfile = new StreamWriter(configLocation))
            {
                outfile.Write(content);
            }
        }

        public static string ReadFile(string configLocation)
        {
            string content = null;

            using (StreamReader sr = new StreamReader(configLocation))
            {
                content = sr.ReadToEnd();
            }

            return content;
        }

        public static void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Close();
                data = null;
            }
        }
    }
}
