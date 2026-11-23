using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Model
{
    public class ParkingSlot : IParkingSlot
    {
        private List<Car> _parkingHistory = null;
        private bool _isAvailable = true;
        private string _responseCode = string.Empty;
        private int _parkingLotSize = 0;

        public ParkingSlot(int ParkingLotSize)
        {
            _parkingHistory = new List<Car>();
            _isAvailable = true;
            _parkingLotSize = ParkingLotSize;
        }

        public bool IsAvailable { get { return _isAvailable; } set { _isAvailable = value; } }

        public string CheckIn(Car car, int ParkingLotNum)
        {//Check already exists
            try
            {
                if (car == null)
                {
                    _responseCode = "P0001";
                    IsAvailable = true;
                    return _responseCode;
                }

                if (ParkingLotNum < 1 || ParkingLotNum > _parkingLotSize)
                {
                    _responseCode = "P0002";
                    IsAvailable = true;
                    return _responseCode;
                }

                IsAvailable = false;
                car.IsInParkingLot = true;
                car.EnterDateTime = DateTime.Now;
                car.AllocatedParkingLot = ParkingLotNum;
                _parkingHistory.Add(car);
                _responseCode = "P0000";
            }
            catch (Exception ex)
            {
                _responseCode = "P0003";
            }

            return _responseCode;
        }

        public string CheckOut(Car car)
        {
            try
            {
                if (_parkingHistory.Find(c => c.IsInParkingLot == true) != null && _parkingHistory.Contains(car))
                {
                    Car OnSpotCar = _parkingHistory.Find(c => c.IsInParkingLot == true);
                    if (OnSpotCar != null && car.PlateNumber.Equals(OnSpotCar.PlateNumber, StringComparison.InvariantCultureIgnoreCase))
                    {
                        IsAvailable = true;
                        OnSpotCar.IsInParkingLot = false;
                        OnSpotCar.LeaveDateTime = DateTime.Now;
                        _responseCode = "P0000";
                    }
                    else
                    {
                        _responseCode = "P0004";
                    }
                }
                else
                {
                    _responseCode = "P0004";
                }
            }
            catch (Exception ex)
            {
                _responseCode = "P0005";
            }

            return _responseCode;
        }

        public List<string> GetNumPlateListByColor(string Color, out string ResponseCode)
        {
            List<string> plateList = new List<string>();
            try
            {
                plateList = _parkingHistory
                .Where(c => c.Color.Equals(Color, StringComparison.InvariantCultureIgnoreCase) && c.IsInParkingLot == true)
                .Select(s => s.PlateNumber)
                .Distinct()
                .ToList();
                ResponseCode = "P0000";
            }
            catch (Exception)
            {
                ResponseCode = "P0006";
            }

            
            return plateList;
        }

        public List<int> GetParkLotNumListByColor(string Color, out string ResponseCode)
        {
            List<int> ParkingLotNumList = new List<int>();
            try
            {
                ParkingLotNumList = _parkingHistory
                .Where(c => c.Color.Equals(Color, StringComparison.InvariantCultureIgnoreCase) && c.IsInParkingLot == true)
                .Select(s => s.AllocatedParkingLot)
                .Distinct()
                .ToList();
                ResponseCode = "P0000";
            }
            catch (Exception)
            {
                ResponseCode = "P0006";
            }


            return ParkingLotNumList;
        }

        public bool IsTheCarInTheSlotNow(string PlateNumber, out string ResponseCode)
        {
            IEnumerable<Car> res = null;

            try
            {
                res = _parkingHistory
                .Where(c => c.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase) && c.IsInParkingLot == true);
                ResponseCode = "P0000";
            }
            catch (Exception)
            {
                ResponseCode = "P0007";
            }
            
            return (res.Count() > 0) ? true : false;
        }

        public bool IsTheCarParkedEver(string PlateNumber, out string ResponseCode)
        {
            IEnumerable<Car> res = null;
            try
            {
                res = _parkingHistory.Where(c => c.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase));
                ResponseCode = "P0000";
            }
            catch (Exception ex)
            {
                ResponseCode = "P0008";
            }
            
            return (res.Count() > 0)? true : false;           
        }

        public Car GetCurrentParkedCar(out string ResponseCode)
        {
            Car c = null;
            try
            {
                c = _parkingHistory.Where(ca => ca.IsInParkingLot == true).FirstOrDefault();
                ResponseCode = "P0000";
            }
            catch (Exception ex)
            {
                ResponseCode = "P0022";
            }
            return c;
        }

        public List<Car> DisplayParkingHistory { get { return _parkingHistory; } }
    }
}
