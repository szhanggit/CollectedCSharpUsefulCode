using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Model
{
    public class AppConst
    {
        public static readonly string CreateCommandTemplate = "Created a parking lot with {0} slots";
        public static readonly string ParkCommandTemplate = "Allocated slot number: {0}";
        public static readonly string ParkCommandFailTemplate = "Sorry, parking lot is full";
        public static readonly string LeaveCommandTemplate = "Slot number {0} is free";
        public static readonly string StatusHead = "Slot No.    Registration No     Colour";
        public static readonly string StatusBody = "{0}           {1}       {2}";
        public static readonly string SearchSlotByCarPlateCommandFailTemplate = "Not Found";
        public static readonly string ExitCommandFailTemplate = "Welcome to use Parking Lot Management System. See you next time.";
    }
}
