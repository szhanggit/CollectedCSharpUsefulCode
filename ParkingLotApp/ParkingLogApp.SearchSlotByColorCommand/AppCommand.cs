using ParkingLogApp.BaseCommand;
using ParkingLogApp.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.SearchSlotByColorCommand
{
    public class AppCommand : IAppCommand
    {
        public AppCommand()
        {

        }

        public string Execute(IParkingLogManagementService service, params object[] list)
        {
            StringBuilder sb = new StringBuilder();
            List<int> ParkingLotNumList = new List<int>();
            string Message = string.Empty;
            if (list.Count() != 1)
            {
                Message = "P0019";
                return Message;
            }

            string Color = list[0].ToString();
            ParkingLotNumList = service.GetParkingLotNumListToColor(Color, out Message);
            Message = string.Join(", ", ParkingLotNumList.ToArray());

            return Message;
        }

        public bool ValidateInput(string CommandMethod, out string Message, params object[] list)
        {
            Message = string.Empty;

            return true;
        }
    }
}
