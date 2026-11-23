using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeperateEx
{
    public static class Helper
    {
        public static List<string> Seperate(string input)
        {
            //return input.Split(Constant.Seperator).Where(s => !string.IsNullOrEmpty(s)).ToList();
            if (input.Last() == Constant.Seperator)
            {
                input = input.Remove(input.Length - 1);
            }
            return input.Split(Constant.Seperator).ToList();
        }
    }
}
