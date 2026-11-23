using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StringContentEx
{
    /*
     https://stackoverflow.com/questions/19479177/what-purposes-should-i-use-class-stringcontent-for
         */
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Provides HTTP content based on a string.
             public StringContent (string content, System.Text.Encoding? encoding, string? mediaType);
             */

            string JsonCustomer = string.Empty;
            StringContent content = new StringContent(JsonCustomer, Encoding.UTF8, "application/json");

        }
    }
}
