using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetPropertiesBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(string);
            PropertyInfo[] info = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Console.WriteLine("Count of Properties = " + info.Length);
            Console.WriteLine("Properties... ");
            for (int i = 0; i < info.Length; i++)
                Console.WriteLine(" {0}", info[i].ToString());


            DateTime dateTime = new DateTime();
            type = dateTime.GetType();

            foreach (System.Reflection.PropertyInfo property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine(property.Name);
            }

            Console.ReadLine();
        }
    }
}
