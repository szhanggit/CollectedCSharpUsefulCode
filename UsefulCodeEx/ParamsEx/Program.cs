using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsEx
{
    /*https://www.cnblogs.com/suntemple/articles/10249558.html*/
    class Program
    {
        static void Main(string[] args)
        {
            UseParams(1, 2, 3); //既可以用任意多个int
            int[] myarray = new int[3] { 10, 11, 12 };
            UseParams(myarray); //也可以是int一维数组
            UseParams2(1, 'a', new object());
        }

        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();
        }

        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();
        }
    }
}
