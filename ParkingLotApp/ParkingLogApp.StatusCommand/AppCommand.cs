using ParkingLogApp.BaseCommand;
using ParkingLogApp.Lib;
using ParkingLogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.StatusCommand
{
    public class AppCommand : IAppCommand
    {
        private StringBuilder sb = new StringBuilder(); 

        public AppCommand()
        {

        }

        public string Execute(IParkingLogManagementService service, params object[] list)
        {
            string Message = string.Empty;
            List<Car> CarList = new List<Car>();
            CarList = service.DisplayAllCurrentParkedCars(out Message);

            sb.AppendLine(AppConst.StatusHead);
            foreach (Car c in CarList)
            {
                sb.AppendLine(string.Format(AppConst.StatusBody, c.AllocatedParkingLot, c.PlateNumber, c.Color));
            }
            return sb.ToString();
        }

        public bool ValidateInput(string CommandMethod, out string Message, params object[] list)
        {
            Message = string.Empty;

            return true;
        }
    }
}
