using ParkingLogApp.BaseCommand;
using ParkingLogApp.Lib;
using ParkingLogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.CreateCommand
{
    public class AppCommand : IAppCommand
    {
        public AppCommand()
        {

        }

        public string Execute(IParkingLogManagementService service, params object[] list)
        {
            int size = 0;
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

            if (ValidateInput("create_parking_lot", out Message, list))
            {
                if (int.TryParse(list[0].ToString(), out size))
                {
                    if (size < 0)
                    {
                        Message = "P0020";
                        return Message;
                    }
                    else
                    {
                        service.SetSize(size);
                    }
                }
                else
                {
                    Message = "P0020";
                    return Message;
                }

                Message = string.Format(AppConst.CreateCommandTemplate, size);
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
