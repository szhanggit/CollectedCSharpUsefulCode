using Notification.CoreInterface;
using Notification.CoreInterface.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoadDistributionEx
{
    class Program
    {
        static void Main(string[] args)
        {
            ProviderBuilder pb = new ProviderBuilder();
            pb.Build<ByVoucherTransactionRequestDto, string>();
        }
    }
}
