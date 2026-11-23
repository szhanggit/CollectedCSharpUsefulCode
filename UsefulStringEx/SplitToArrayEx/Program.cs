using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitToArrayEx
{
    class Program
    {
        static void Main(string[] args)
        {
            char seperator = '|';
            char seperator2 = '-';
            string BigStr = "a | sd | fl  ak |j| d ||| fla | jds | flj | ald | jsfd  | s |f  ";
            var stringArr = BigStr.Split(new char[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string dateStr = "2021-05-01";
            stringArr = dateStr.Split(new char[] { seperator2 }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
