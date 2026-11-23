using ParkingLogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Lib
{
    public interface IParkingLogManagementService
    {
        Dictionary<int, ParkingSlot> DisplayParkingLotDictionary { get; }
        void SetSize(int size);
        int GetParkingLotNum(Car car, out string _responseCode);
        string LeaveParkingLot(int ParkingLogNum);
        List<string> GetNumberPlateListToColor(string Color, out string _responseCode);
        int GetSlotNumForAParkedCar(string PlateNum, out string _responseCode);
        List<int> GetSlotNumListWhereTheCarParkedEver(string PlateNum, out string _responseCode);
        List<Car> DisplayAllCurrentParkedCars(out string _responseCode);
        List<int> GetParkingLotNumListToColor(string Color, out string _responseCode);
    }
}
