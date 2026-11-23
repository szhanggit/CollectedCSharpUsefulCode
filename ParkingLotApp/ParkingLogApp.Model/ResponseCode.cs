using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Model
{
    public class ResponseCode
    {
        public static readonly string P0000 = "Operation Success";
        public static readonly string P0001 = "There is no car to check in.";
        public static readonly string P0002 = "There is no such parking number.";
        public static readonly string P0003 = "There is an unhandled check in exception.";
        public static readonly string P0004 = "There is no such car to check out.";
        public static readonly string P0005 = "There is an unhandled check out exception.";
        public static readonly string P0006 = "There is an unhandled exception at GetNumPlateListByColor.";
        public static readonly string P0007 = "There is an unhandled exception at IsTheCarInTheSlotNow.";
        public static readonly string P0008 = "There is an unhandled exception at IsTheCarParked.";
        public static readonly string P0009 = "Sorry, parking lot is full.";
        public static readonly string P0010 = "There is an unhandled exception at GetParkingLotNum.";
        public static readonly string P0011 = "There is no such parking lot number.";
        public static readonly string P0012 = "There is an unhandled exception at LeaveParkingLot.";
        public static readonly string P0013 = "There is no car in such color.";
        public static readonly string P0014 = "There is an unhandled exception at GetNumberPlateListToColor.";
        public static readonly string P0015 = "There is an unhandled exception at GetSlotNumListWhereTheCarParkedEver.";
        public static readonly string P0016 = "The car never visits the parkinglot.";
        public static readonly string P0017 = "There is an unhandled exception at GetSlotNumForAParkedCar.";
        public static readonly string P0018 = "There is no such car in the parking lot.";
        public static readonly string P0019 = "Your input is more than needed.";
        public static readonly string P0020 = "Your input is not valid.";
        public static readonly string P0021 = "Please make your inputs.";
        public static readonly string P0022 = "There is an unhandled exception at GetCurrentParkedCar.";
        public static readonly string P0023 = "There is an unhandled exception at DisplayAllCurrentParkedCars.";
    }
}
