using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Model
{
    public interface IParkingSlot
    {
        bool IsAvailable { get; set; }
        string CheckIn(Car car, int ParkingLotNum);
        string CheckOut(Car car);
        List<string> GetNumPlateListByColor(string Color, out string ResponseCode);
        bool IsTheCarInTheSlotNow(string PlateNumber, out string ResponseCode);
        bool IsTheCarParkedEver(string PlateNumber, out string ResponseCode);
        List<Car> DisplayParkingHistory { get; }
    }
}
