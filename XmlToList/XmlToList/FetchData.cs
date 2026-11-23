using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public class FetchData
    {
        public FetchData()
        {

        }

        public string GetData()
        {
            string line = string.Empty;
            using (StreamReader reader = File.OpenText(@"D:\E\Experiments\XmlToList\File.txt"))
            {
                line = reader.ReadLine();
            }

            return line;
        }
    }
}
