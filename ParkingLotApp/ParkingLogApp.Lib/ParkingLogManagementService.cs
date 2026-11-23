using ParkingLogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Lib
{
    public class ParkingLogManagementService : IParkingLogManagementService
    {
        private Dictionary<int, ParkingSlot> _parkingLotDic = null;
        private string _responseCode = string.Empty;

        public ParkingLogManagementService(int SlotNum)
        {
            _parkingLotDic = new Dictionary<int, ParkingSlot>();
            for (int i = 1; i <= SlotNum; i++)
            {
                _parkingLotDic.Add(i, new ParkingSlot(SlotNum));
            }            
        }

        public void SetSize(int size)
        {
            _parkingLotDic = new Dictionary<int, ParkingSlot>();
            for (int i = 1; i <= size; i++)
            {
                _parkingLotDic.Add(i, new ParkingSlot(size));
            }
        }

        public Dictionary<int, ParkingSlot> DisplayParkingLotDictionary { get { return _parkingLotDic; } }

        public int GetParkingLotNum(Car car, out string _responseCode)
        {
            int ParkingLogNum = -1;
            try
            {
                var slot = _parkingLotDic.Where(p => p.Value.IsAvailable == true).OrderBy(s => s.Key)
                .Select(p => new { Key = p.Key, Value = p.Value }).FirstOrDefault();
                if (slot != null)
                {
                    ParkingLogNum = slot.Key;
                    _responseCode = _parkingLotDic[ParkingLogNum].CheckIn(car, ParkingLogNum);
                }
                else
                {
                    _responseCode = "P0009";
                }
            }
            catch (Exception ex)
            {
                _responseCode = "P0010";
            }
           
            return ParkingLogNum;
        }

        public string LeaveParkingLot(int ParkingLogNum)
        {
            try
            {
                if (_parkingLotDic.ContainsKey(ParkingLogNum))
                {
                    Car car = _parkingLotDic[ParkingLogNum].DisplayParkingHistory.Where(c => c.IsInParkingLot == true).FirstOrDefault();
                    _responseCode = _parkingLotDic[ParkingLogNum].CheckOut(car);
                }
                else
                {
                    _responseCode = "P0011";                    
                }
            }
            catch (Exception ex)
            {
                _responseCode = "P0012";
            }

            return _responseCode;
        }

        public List<string> GetNumberPlateListToColor(string Color, out string _responseCode)
        {
            string _InnerResponseCode = string.Empty;
            List<string> list = new List<string>();
            try
            {
                foreach (int ParkingLogNum in _parkingLotDic.Keys)
                {
                    list.AddRange(_parkingLotDic[ParkingLogNum].GetNumPlateListByColor(Color, out _InnerResponseCode));
                }
            }
            catch (Exception ex)
            {
                _responseCode = "P0014";
            }
            
            if (list.Count > 0)
            {
                _responseCode = _InnerResponseCode;
                return list.Distinct().ToList();
            }
            else
            {
                _responseCode = "P0013";
                return list;
            }            
        }

        public List<int> GetParkingLotNumListToColor(string Color, out string _responseCode)
        {
            string _InnerResponseCode = string.Empty;
            List<int> list = new List<int>();
            try
            {
                foreach (int ParkingLogNum in _parkingLotDic.Keys)
                {
                    list.AddRange(_parkingLotDic[ParkingLogNum].GetParkLotNumListByColor(Color, out _InnerResponseCode));
                }
            }
            catch (Exception ex)
            {
                _responseCode = "P0014";
            }

            if (list.Count > 0)
            {
                _responseCode = _InnerResponseCode;
                return list.Distinct().ToList();
            }
            else
            {
                _responseCode = "P0013";
                return list;
            }
        }

        public int GetSlotNumForAParkedCar(string PlateNum, out string _responseCode)
        {
            string innerResponseCode = string.Empty;
            int SlotNum = -1;
            try
            {
                foreach (int ParkingLogNum in _parkingLotDic.Keys)
                {
                    if (_parkingLotDic[ParkingLogNum].IsTheCarInTheSlotNow(PlateNum, out innerResponseCode))
                    {
                        SlotNum = ParkingLogNum;
                    }
                }
                _responseCode = innerResponseCode;

                if (SlotNum == -1)
                {
                    _responseCode = "P0018";
                }
            }
            catch (Exception ex)
            {
                _responseCode = "P0017";
            }
            
            return SlotNum;
        }

        public List<int> GetSlotNumListWhereTheCarParkedEver(string PlateNum, out string _responseCode)
        {
            string innerResponseCode = string.Empty;
            List<int> SlotNumList = new List<int>();
            try
            {
                foreach (int ParkingLogNum in _parkingLotDic.Keys)
                {
                    if (_parkingLotDic[ParkingLogNum].IsTheCarParkedEver(PlateNum, out innerResponseCode))
                    {
                        SlotNumList.Add(ParkingLogNum);
                    }
                }
            }
            catch (Exception)
            {
                _responseCode = "P0015";
            }

            _responseCode = (SlotNumList.Count > 0)? innerResponseCode : "P0016";
            return SlotNumList;
        }

        public List<Car> DisplayAllCurrentParkedCars(out string _responseCode)
        {
            string innerResponseCode = string.Empty;
            List<Car> CarList = new List<Car>();
            try
            {
                foreach (int ParkingLogNum in _parkingLotDic.Keys)
                {

                    Car c = _parkingLotDic[ParkingLogNum].GetCurrentParkedCar(out innerResponseCode);
                    if (c != null)
                    {
                        CarList.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                _responseCode = "P0023";
            }

            _responseCode = innerResponseCode;
            return CarList;
        }
    }
}
