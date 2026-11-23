using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryConvertExcelDateTimeEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string txtDate = "04/02/21";
            DateTime dt = new DateTime();
            Helper.TryConvertExcelDateTime(txtDate, out dt);
        }
    }
}
