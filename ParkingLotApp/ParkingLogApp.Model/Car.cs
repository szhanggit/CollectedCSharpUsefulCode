using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLogApp.Model
{
    public class Car
    {
        public Car()
        {

        }

        public string CarGUID { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public bool IsInParkingLot { get; set; }
        public DateTime EnterDateTime { get; set; }
        public DateTime? LeaveDateTime { get; set; }
        public int AllocatedParkingLot { get; set; }
    }
}
