using ParkingLogApp.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.BaseCommand
{
    public interface IAppCommand
    {
        string Execute(IParkingLogManagementService service, params object[] list);
        bool ValidateInput(string CommandMethod, out string Message, params object[] list);
    }
}
