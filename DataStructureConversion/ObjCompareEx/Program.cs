using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjCompareEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account { AccountNumber = "asdf", ProgramCode = "fdsa" };
            Account a2 = new Account { AccountNumber = "asdf", ProgramCode = "fdsa" };
            bool flag = a1.Equals(a2);
        }
    }
}
