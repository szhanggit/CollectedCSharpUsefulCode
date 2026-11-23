using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64BasedStringToBytes
{
    class Program
    {
        static void Main(string[] args)
        {
            //www.text(it will return 64based string.Therefore, need to convert the 64 based string to bytes and convert it to utf-8 based string)

            //https://docs.microsoft.com/en-us/dotnet/api/system.convert.frombase64string?view=netframework-4.8
            // Define a byte array.
            byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            Console.WriteLine("The byte array: ");
            Console.WriteLine("   {0}\n", BitConverter.ToString(bytes));

            // Convert the array to a base 64 sring.
            String s = Convert.ToBase64String(bytes);
            Console.WriteLine("The base 64 string:\n   {0}\n", s);

            // Restore the byte array.
            byte[] newBytes = Convert.FromBase64String(s);
            Console.WriteLine("The restored byte array: ");
            Console.WriteLine("   {0}\n", BitConverter.ToString(newBytes));
        }
    }
}
