using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemConfigEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string BillingBoxPICID = "BillingBoxPICID".ConfigStringValue();
            int BillingBoxFTPHostPort = "BillingBoxFTPHostPort".ConfigIntValue(0);
            bool EnableTraceSql = "EnableTraceSql".ConfigBoolValue();
            var list = "CreditLimitSkipModel".ConfigListValue();
        }
    }
}
