using eVoucher.MO.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadAssemblyEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = (IVoucherGenerator)Activator.CreateInstance("eVoucher.Mo.Extend", "eVoucher.Mo.Extend.EdenredVoucherGenerator").Unwrap();
        }
    }
}
