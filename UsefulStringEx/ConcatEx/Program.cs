using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcatEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string CustomerFName = "Peter";
            string CustomerMName = "MSD";
            string CustomerLName = "Black";

            string RecipientName = string.Concat(CustomerFName, " ", CustomerMName, " ", CustomerLName);

        }
    }
}
