using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrimEndEx
{
    class Program
    {
        /*
         https://www.geeksforgeeks.org/c-sharp-trimstart-and-trimend-method/	
             */
        static void Main(string[] args)
        {
            // Our example string array.
            string[] items = new string[]
            {
                "Who's there?",
                "I am here..."
            };

            /*
                char[] arr = new char[] { '\t', ',', ' ' }; // Trim these characters.
                text = text.TrimStart(arr);
             */

            // Loop and call TrimEnd.
            foreach (string item in items)
            {
                string trimmed = item.TrimEnd('?', '.', ',');
                Console.WriteLine(item);
                Console.WriteLine("    " + trimmed);
            }
            Console.ReadLine();
        }
    }
}
