using ParkingLogApp.BaseCommand;
using ParkingLogApp.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.SearchCarPlatesByColorCommand
{
    public class AppCommand : IAppCommand
    {
        public AppCommand()
        {

        }

        public string Execute(IParkingLogManagementService service, params object[] list)
        {
            StringBuilder sb = new StringBuilder();
            List<string> CarPlateList = new List<string>();
            string Message = string.Empty;
            if (list.Count() != 1)
            {
                Message = "P0019";
                return Message;
            }

            string Color = list[0].ToString();
            CarPlateList = service.GetNumberPlateListToColor(Color, out Message);
            Message = string.Join(", ", CarPlateList.ToArray());

            return Message;
        }

        public bool ValidateInput(string CommandMethod, out string Message, params object[] list)
        {
            Message = string.Empty;

            return true;
        }
    }
}
