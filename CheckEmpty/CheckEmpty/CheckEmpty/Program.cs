using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckEmpty
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher t = null;
            int? _level = t?.Level;
            string _firstName = t?.FirstName;
        }
    }
}
