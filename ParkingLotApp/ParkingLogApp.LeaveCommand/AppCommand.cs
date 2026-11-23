using ParkingLogApp.BaseCommand;
using ParkingLogApp.Lib;
using ParkingLogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.LeaveCommand
{
    public class AppCommand : IAppCommand
    {
        public AppCommand()
        {

        }

        public string Execute(IParkingLogManagementService service, params object[] list)
        {
            int ParkingLotNum = 0;
            string Message = string.Empty;

            if (list.Count() == 0)
            {
                Message = "P0021";
                return Message;
            }

            if (list.Count() > 1)
            {
                Message = "P0019";
                return Message;
            }

            if (int.TryParse(list[0].ToString(), out ParkingLotNum))
            {
                if (ParkingLotNum < 0)
                {
                    Message = "P0020";
                    return Message;
                }
                else
                {
                    Message = service.LeaveParkingLot(ParkingLotNum);
                }
            }
            else
            {
                Message = "P0020";
                return Message;
            }

            Message = string.Format(AppConst.LeaveCommandTemplate, ParkingLotNum);
            return Message;
        }

        public bool ValidateInput(string CommandMethod, out string Message, params object[] list)
        {
            Message = string.Empty;

            return true;
        }
    }
}
