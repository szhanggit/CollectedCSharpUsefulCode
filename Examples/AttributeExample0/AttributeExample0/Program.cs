using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeExample0
{
    class Program
    {
        static void Main(string[] args)
        {
            MWVEmailTemplate mWVEmailTemplate = MWVEmailTemplate.Original;
            bool flag = mWVEmailTemplate.isSmartVoucher();
        }
    }
}
