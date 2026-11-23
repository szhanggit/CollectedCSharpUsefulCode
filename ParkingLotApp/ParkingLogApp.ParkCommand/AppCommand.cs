using ParkingLogApp.BaseCommand;
using ParkingLogApp.Lib;
using ParkingLogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.ParkCommand
{
    public class AppCommand : IAppCommand
    {
        public AppCommand()
        {

        }

        public string Execute(IParkingLogManagementService service, params object[] list)
        {
            string Message = string.Empty;

            if (list.Count() < 2)
            {
                Message = "P0021";
                return Message;
            }

            if (list.Count() > 2)
            {
                Message = "P0019";
                return Message;
            }

            if (ValidateInput("park", out Message, list))
            {
                string CarPlate = list[0].ToString();
                string Color = list[1].ToString();
                Car car = new Car
                {
                    CarGUID = Guid.NewGuid().ToString(),
                    PlateNumber = CarPlate,
                    Color = Color
                };

                int ParkingSlotNumber = service.GetParkingLotNum(car, out Message);
                if (ParkingSlotNumber > 0)
                {
                    Message = string.Format(AppConst.ParkCommandTemplate, ParkingSlotNumber);
                }
                else
                {
                    Message = AppConst.ParkCommandFailTemplate;
                }
            }


            

            return Message;
        }

        public bool ValidateInput(string CommandMethod, out string Message, params object[] list)
        {
            Message = string.Empty;

            return true;
        }
    }
}
