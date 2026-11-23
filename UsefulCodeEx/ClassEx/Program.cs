using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEx
{
    /*
     https://www.cnblogs.com/madkex/archive/2012/05/29/2523977.html
         */
    class Program
    {
        static void Main(string[] args)
        {
            myclass mc = 1;//通过隐式装换，生成myclass对象
            Console.WriteLine(mc.Value);
            myclass mc2 = new myclass(2);
            Console.WriteLine((int)mc2);//显示转化，调用myclass至int的处理方法
            Console.WriteLine(mc2);//隐式转化，调用myclass至string的处理方法
        }
    }
}
