using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.CoreInterface
{
    public interface INotification<RQ, RS>
    {
        bool ValidateParams(RQ request, out string errors);

        string DoNotify(RQ request, out RS response);

        IDictionary<string, string> ExtensionData { get; }
    }
}
