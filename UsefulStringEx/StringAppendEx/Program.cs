using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAppendEx
{
    class Program
    {
        public static string Append(params object[] objs)
        {
            var stringBuilder = new StringBuilder();

            foreach (var obj in objs)
            {
                stringBuilder.Append(obj);
            }

            return stringBuilder.ToString();
        }

        static void Main(string[] args)
        {
            string str = Append("aa", "bb", "cc", "dd");
        }
    }
}
