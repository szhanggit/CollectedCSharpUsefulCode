using ParkingLogApp.BaseCommand;
using ParkingLogApp.Lib;
using ParkingLogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.SearchSlotByCarPlateCommand
{
    public class AppCommand : IAppCommand
    {
        public AppCommand()
        {

        }

        public string Execute(IParkingLogManagementService service, params object[] list)
        {
            int ParkingLotNum = -1;
            string Message = string.Empty;
            if (list.Count() != 1)
            {
                Message = "P0019";
                return Message;
            }

            string PlateNumber = list[0].ToString();
            ParkingLotNum = service.GetSlotNumForAParkedCar(PlateNumber, out Message);
            Message = (ParkingLotNum > 0) ? ParkingLotNum.ToString() : AppConst.SearchSlotByCarPlateCommandFailTemplate;

            return Message;
        }

        public bool ValidateInput(string CommandMethod, out string Message, params object[] list)
        {
            Message = string.Empty;

            return true;
        }
    }
}
