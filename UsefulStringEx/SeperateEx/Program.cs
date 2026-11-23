using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeperateEx
{
    class Program
    {
        public const char Seperator = '|';

        public static List<string> Seperate(string input)
        {
            //return input.Split(Constant.Seperator).Where(s => !string.IsNullOrEmpty(s)).ToList();
            if (input.Last() == Seperator)
            {
                input = input.Remove(input.Length - 1);
            }
            return input.Split(Seperator).ToList();
        }

        static void Main(string[] args)
        {
            string strstream = "luka|erfl|kjdv|flk|ais|df|";
            var list = Seperate(strstream);
        }
    }
}
