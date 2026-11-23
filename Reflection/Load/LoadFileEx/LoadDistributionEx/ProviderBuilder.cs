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
    public class ProviderBuilder
    {
        public void Build<RQ, RS>()
        {
            try
            {
                INotification<RQ, RS> service = null;
                Assembly asm = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notification.Impl.dll"));
                service = asm.CreateInstance("Notification.Impl.ByVoucherTransactionNotification") as INotification<RQ, RS>;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
