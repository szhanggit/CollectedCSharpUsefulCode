using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLogApp.Model;

namespace ParkingLogApp.Test
{
    [TestClass]
    public class ParkingSlotTest
    {
        IParkingSlot ps = null;
        int ParkingLotSize = 6;

        public ParkingSlotTest()
        {
            ps = new ParkingSlot(ParkingLotSize);
        }

        [TestMethod]
        public void TestNormalCheckIn()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLotNum = 1;
            Car c = new Car {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID
            };

            string ResponseCode = ps.CheckIn(c, ParkingLotNum);

            Assert.AreEqual(ResponseCode, "P0000");
            Assert.IsNotNull(ps.DisplayParkingHistory);
            Assert.IsNotNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true));
            Assert.AreEqual(PlateNumber, ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true).PlateNumber);
            Assert.AreEqual(Color, ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true).Color);
            Assert.AreEqual(CarGUID, ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true).CarGUID);
            Assert.AreEqual(ParkingLotNum, ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true).AllocatedParkingLot);
            Assert.IsNotNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true).EnterDateTime);
            Assert.IsNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true).LeaveDateTime);
            Assert.IsTrue(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true).IsInParkingLot);
            Assert.IsFalse(ps.IsAvailable);
        }

        [TestMethod]
        public void TestEmptyCarCheckIn()
        {
            int ParkingLotNum = 1;
            Car c = null;

            string ResponseCode = ps.CheckIn(c, ParkingLotNum);

            Assert.AreEqual(ResponseCode, "P0001");
            Assert.IsNotNull(ps.DisplayParkingHistory);
            Assert.IsNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true));
            Assert.IsTrue(ps.IsAvailable);
        }

        [TestMethod]
        public void TestCheckInWithInvalidParkingLotNum()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLotNum = 100;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID
            };

            string ResponseCode = ps.CheckIn(c, ParkingLotNum);

            Assert.AreEqual(ResponseCode, "P0002");
            Assert.IsNotNull(ps.DisplayParkingHistory);
            Assert.IsNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true));
            Assert.IsTrue(ps.IsAvailable);
        }

        [TestMethod]
        public void TestNormalCheckOut()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = CarColor.White.ToString();
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLogNum = 2;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            ps.DisplayParkingHistory.Add(c);

            string ResponseCode = ps.CheckOut(c);

            Assert.AreEqual(ResponseCode, "P0000");
            Assert.IsNotNull(ps.DisplayParkingHistory);
            Assert.IsNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true));
            Assert.IsNotNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == false));
            Assert.AreEqual(PlateNumber, 
                ps.DisplayParkingHistory.Find(ca => ca.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase) 
                && ca.IsInParkingLot == false).PlateNumber);
            Assert.AreEqual(Color, ps.DisplayParkingHistory.Find(ca => ca.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase)
                && ca.IsInParkingLot == false).Color);
            Assert.AreEqual(CarGUID, ps.DisplayParkingHistory.Find(ca => ca.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase)
                && ca.IsInParkingLot == false).CarGUID);
            Assert.AreEqual(ParkingLogNum, ps.DisplayParkingHistory.Find(ca => ca.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase)
                && ca.IsInParkingLot == false).AllocatedParkingLot);
            Assert.IsNotNull(ps.DisplayParkingHistory.Find(ca => ca.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase)
                && ca.IsInParkingLot == false).EnterDateTime);
            Assert.IsNotNull(ps.DisplayParkingHistory.Find(ca => ca.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase)
                && ca.IsInParkingLot == false).LeaveDateTime);
            Assert.IsFalse(ps.DisplayParkingHistory.Find(ca => ca.PlateNumber.Equals(PlateNumber, StringComparison.InvariantCultureIgnoreCase)
                && ca.IsInParkingLot == false).IsInParkingLot);
            Assert.IsTrue(ps.IsAvailable);
        }

        [TestMethod]
        public void TestCheckOutWithNoSuchCar()
        {
            string PlateNumber = "KA-01-HH-1234";
            string PlateNumber2 = "KA-01-HH-2345";
            string Color = CarColor.White.ToString();
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLogNum = 2;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            ps.DisplayParkingHistory.Add(c);
            ps.IsAvailable = false;

            Car c2 = new Car
            {
                PlateNumber = PlateNumber2,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };

            string ResponseCode = ps.CheckOut(c2);

            Assert.AreEqual(ResponseCode, "P0004");
            Assert.IsNotNull(ps.DisplayParkingHistory);
            Assert.IsNotNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == true));
            Assert.IsNull(ps.DisplayParkingHistory.Find(ca => ca.IsInParkingLot == false));
            Assert.IsFalse(ps.IsAvailable);
        }

        [TestMethod]
        public void TestGetNumPlateListByColorWithSuccess()
        {
            string ResponseMessage = string.Empty;
            string PlateNumber = "KA-01-HH-1234";
            string Color = CarColor.White.ToString();
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLogNum = 2;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            Car c3 = new Car
            {
                PlateNumber = PlateNumber,
                Color = CarColor.Black.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            ps.DisplayParkingHistory.Add(c);
            ps.DisplayParkingHistory.Add(c2);
            ps.DisplayParkingHistory.Add(c3);
            List<string> ExpectedList = new List<string>{ "KA-01-HH-1234", "KA-01-HH-2345" };

            var list = ps.GetNumPlateListByColor(CarColor.White.ToString(), out ResponseMessage);

            CollectionAssert.AreEqual(ExpectedList, list);
            Assert.AreEqual(ResponseMessage, "P0000");
        }

        [TestMethod]
        public void TestGetNumPlateListByColorWithEmpty()
        {
            string ResponseMessage = string.Empty;
            string PlateNumber = "KA-01-HH-1234";
            string Color = CarColor.White.ToString();
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLogNum = 2;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            Car c3 = new Car
            {
                PlateNumber = PlateNumber,
                Color = CarColor.Black.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            ps.DisplayParkingHistory.Add(c);
            ps.DisplayParkingHistory.Add(c2);
            ps.DisplayParkingHistory.Add(c3);
            List<string> ExpectedList = new List<string>();

            var list = ps.GetNumPlateListByColor(CarColor.Red.ToString(), out ResponseMessage);

            CollectionAssert.AreEqual(ExpectedList, list);
            Assert.AreEqual(ResponseMessage, "P0000");
        }

        [TestMethod]
        public void TestIsTheCarInTheSlotNowWithTrue()
        {
            string ResponseMessage = string.Empty;
            string PlateNumber = "KA-01-HH-1234";
            string Color = CarColor.White.ToString();
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLogNum = 2;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            Car c3 = new Car
            {
                PlateNumber = PlateNumber,
                Color = CarColor.Black.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            ps.DisplayParkingHistory.Add(c);
            ps.DisplayParkingHistory.Add(c2);
            ps.DisplayParkingHistory.Add(c3);

            bool result = ps.IsTheCarInTheSlotNow(PlateNumber, out ResponseMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(ResponseMessage, "P0000");
        }

        [TestMethod]
        public void TestIsTheCarInTheSlotNowWithFalse()
        {
            string ResponseMessage = string.Empty;
            string PlateNumber = "KA-01-HH-1234";
            string Color = CarColor.White.ToString();
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLogNum = 2;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            Car c3 = new Car
            {
                PlateNumber = "KA-01-HH-3456",
                Color = CarColor.Black.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            ps.DisplayParkingHistory.Add(c2);
            ps.DisplayParkingHistory.Add(c3);

            bool result = ps.IsTheCarInTheSlotNow(PlateNumber, out ResponseMessage);

            Assert.IsFalse(result);
            Assert.AreEqual(ResponseMessage, "P0000");
        }

        [TestMethod]
        public void TestIsTheCarParkedEverWithTrue()
        {
            string ResponseMessage = string.Empty;
            string PlateNumber = "KA-01-HH-1234";
            string Color = CarColor.White.ToString();
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLogNum = 2;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = false
            };
            Car c2 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = false
            };
            Car c3 = new Car
            {
                PlateNumber = PlateNumber,
                Color = CarColor.Black.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            ps.DisplayParkingHistory.Add(c);
            ps.DisplayParkingHistory.Add(c2);
            ps.DisplayParkingHistory.Add(c3);

            bool result = ps.IsTheCarParkedEver(PlateNumber, out ResponseMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(ResponseMessage, "P0000");
        }

        [TestMethod]
        public void TestIsTheCarParkedEverWithFalse()
        {
            string ResponseMessage = string.Empty;
            string PlateNumber = "KA-01-HH-1234";
            string Color = CarColor.White.ToString();
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLogNum = 2;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = false
            };
            Car c2 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = false
            };
            Car c3 = new Car
            {
                PlateNumber = "KA-01-HH-3456",
                Color = CarColor.Black.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLogNum,
                EnterDateTime = DateTime.Now,
                IsInParkingLot = true
            };
            ps.DisplayParkingHistory.Add(c2);
            ps.DisplayParkingHistory.Add(c3);

            bool result = ps.IsTheCarParkedEver(PlateNumber, out ResponseMessage);

            Assert.IsFalse(result);
            Assert.AreEqual(ResponseMessage, "P0000");
        }
    }
}
