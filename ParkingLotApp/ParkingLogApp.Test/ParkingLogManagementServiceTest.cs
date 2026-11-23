using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLogApp.Lib;
using ParkingLogApp.Model;

namespace ParkingLogApp.Test
{
    [TestClass]
    public class ParkingLogManagementServiceTest
    {
        private int size = 6;
        private string ResponseCode = string.Empty;
        private ParkingLogManagementService plms = null;

        public ParkingLogManagementServiceTest()
        {
            plms = new ParkingLogManagementService(size);
        }

        [TestMethod]
        public void TestParkingLogManagementServiceConstructor()
        {
            int size = 6;
            ParkingLogManagementService plms2 = new ParkingLogManagementService(size);
            Assert.AreEqual(size, plms2.DisplayParkingLotDictionary.Count);
            Assert.IsNotNull(plms2.DisplayParkingLotDictionary[1]);
            Assert.IsNotNull(plms2.DisplayParkingLotDictionary[2]);
            Assert.IsNotNull(plms2.DisplayParkingLotDictionary[3]);
            Assert.IsNotNull(plms2.DisplayParkingLotDictionary[4]);
            Assert.IsNotNull(plms2.DisplayParkingLotDictionary[5]);
            Assert.IsNotNull(plms2.DisplayParkingLotDictionary[6]);            
        }

        [TestMethod]
        public void TestGetParkingLotNumWithEmptyParkingLot()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLotNum = -1;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID
            };

            ParkingLotNum = plms.GetParkingLotNum(c, out ResponseCode);

            Assert.AreEqual(1, ParkingLotNum);
            Assert.AreEqual("P0000", ResponseCode);
            Assert.IsFalse(plms.DisplayParkingLotDictionary[1].IsAvailable);               
        }

        [TestMethod]
        public void TestGetParkingLotNumWithHalfFullParkingLot()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLotNum = -1;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID
            };
            plms.DisplayParkingLotDictionary[1].IsAvailable = false;
            plms.DisplayParkingLotDictionary[2].IsAvailable = false;
            plms.DisplayParkingLotDictionary[3].IsAvailable = false;
            plms.DisplayParkingLotDictionary[4].IsAvailable = true;
            plms.DisplayParkingLotDictionary[5].IsAvailable = false;
            plms.DisplayParkingLotDictionary[6].IsAvailable = false;

            ParkingLotNum = plms.GetParkingLotNum(c, out ResponseCode);

            Assert.AreEqual(4, ParkingLotNum);
            Assert.AreEqual("P0000", ResponseCode);
            Assert.IsFalse(plms.DisplayParkingLotDictionary[1].IsAvailable);
        }

        [TestMethod]
        public void TestGetParkingLotNumWithNoParkingSpot()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLotNum = -1;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID
            };
            plms.DisplayParkingLotDictionary[1].IsAvailable = false;
            plms.DisplayParkingLotDictionary[2].IsAvailable = false;
            plms.DisplayParkingLotDictionary[3].IsAvailable = false;
            plms.DisplayParkingLotDictionary[4].IsAvailable = false;
            plms.DisplayParkingLotDictionary[5].IsAvailable = false;
            plms.DisplayParkingLotDictionary[6].IsAvailable = false;

            ParkingLotNum = plms.GetParkingLotNum(c, out ResponseCode);

            Assert.AreEqual(-1, ParkingLotNum);
            Assert.AreEqual("P0009", ResponseCode);
            Assert.IsFalse(plms.DisplayParkingLotDictionary[1].IsAvailable);
        }

        [TestMethod]
        public void TestLeaveParkingLotWithSuccess()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLotNum = 1;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLotNum,
                IsInParkingLot = true
            };
            plms.DisplayParkingLotDictionary[ParkingLotNum].DisplayParkingHistory.Add(c);
            plms.DisplayParkingLotDictionary[ParkingLotNum].IsAvailable = false;

            ResponseCode = plms.LeaveParkingLot(ParkingLotNum);

            Assert.AreEqual("P0000", ResponseCode);
            Assert.IsTrue(plms.DisplayParkingLotDictionary[1].IsAvailable);
        }

        [TestMethod]
        public void TestLeaveParkingLotWithFailure()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            int ParkingLotNum = 100;
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLotNum,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = ParkingLotNum,
                IsInParkingLot = true
            };
            plms.DisplayParkingLotDictionary[1].DisplayParkingHistory.Add(c);
            plms.DisplayParkingLotDictionary[1].IsAvailable = false;

            ResponseCode = plms.LeaveParkingLot(ParkingLotNum);

            Assert.AreEqual("P0011", ResponseCode);
            Assert.IsFalse(plms.DisplayParkingLotDictionary[1].IsAvailable);
        }

        [TestMethod]
        public void TestGetNumberPlateListToColorWithSuccess()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = 1,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = PlateNumber,
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 2,
                IsInParkingLot = true
            };
            Car c3 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.Blue.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 3,
                IsInParkingLot = true
            };
            Car c4 = new Car
            {
                PlateNumber = "KA-01-HH-3456",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 2,
                IsInParkingLot = true
            };
            plms.DisplayParkingLotDictionary[1].DisplayParkingHistory.Add(c);
            plms.DisplayParkingLotDictionary[2].DisplayParkingHistory.Add(c2);
            plms.DisplayParkingLotDictionary[3].DisplayParkingHistory.Add(c3);
            plms.DisplayParkingLotDictionary[4].DisplayParkingHistory.Add(c4);
            List<string> ExpectedList = new List<string> { "KA-01-HH-1234", "KA-01-HH-3456" };

            var list = plms.GetNumberPlateListToColor(CarColor.White.ToString(), out ResponseCode);

            Assert.AreEqual("P0000", ResponseCode);
            CollectionAssert.AreEqual(ExpectedList, list);
        }

        [TestMethod]
        public void TestGetNumberPlateListToColorWithFailure()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = 1,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = PlateNumber,
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 2,
                IsInParkingLot = true
            };
            Car c3 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.Blue.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 3,
                IsInParkingLot = true
            };
            Car c4 = new Car
            {
                PlateNumber = "KA-01-HH-3456",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 2,
                IsInParkingLot = true
            };
            plms.DisplayParkingLotDictionary[1].DisplayParkingHistory.Add(c);
            plms.DisplayParkingLotDictionary[2].DisplayParkingHistory.Add(c2);
            plms.DisplayParkingLotDictionary[3].DisplayParkingHistory.Add(c3);
            plms.DisplayParkingLotDictionary[4].DisplayParkingHistory.Add(c4);

            var list = plms.GetNumberPlateListToColor(CarColor.Red.ToString(), out ResponseCode);

            Assert.AreEqual("P0013", ResponseCode);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestGetSlotNumForAParkedCarWithSuccess()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = 1,
                IsInParkingLot = true
            };
            plms.DisplayParkingLotDictionary[1].DisplayParkingHistory.Add(c);

            int ParkingLogNumber = plms.GetSlotNumForAParkedCar(PlateNumber, out ResponseCode);

            Assert.AreEqual("P0000", ResponseCode);
            Assert.AreEqual(1, ParkingLogNumber);
        }

        [TestMethod]
        public void TestGetSlotNumForAParkedCarWithFailure()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = 1,
                IsInParkingLot = false
            };
            plms.DisplayParkingLotDictionary[1].DisplayParkingHistory.Add(c);

            int ParkingLogNumber = plms.GetSlotNumForAParkedCar(PlateNumber, out ResponseCode);

            Assert.AreEqual("P0018", ResponseCode);
            Assert.AreEqual(-1, ParkingLogNumber);
        }

        [TestMethod]
        public void TestGetSlotNumListWhereTheCarParkedEverWithSuccess()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = 1,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = PlateNumber,
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 2,
                IsInParkingLot = true
            };
            Car c3 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.Blue.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 3,
                IsInParkingLot = true
            };
            Car c4 = new Car
            {
                PlateNumber = "KA-01-HH-3456",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 2,
                IsInParkingLot = true
            };
            plms.DisplayParkingLotDictionary[1].DisplayParkingHistory.Add(c);
            plms.DisplayParkingLotDictionary[2].DisplayParkingHistory.Add(c2);
            plms.DisplayParkingLotDictionary[3].DisplayParkingHistory.Add(c3);
            plms.DisplayParkingLotDictionary[4].DisplayParkingHistory.Add(c4);
            List<int> ExpectedList = new List<int> { 1, 2 };

            var list = plms.GetSlotNumListWhereTheCarParkedEver(PlateNumber, out ResponseCode);

            Assert.AreEqual("P0000", ResponseCode);
            CollectionAssert.AreEqual(ExpectedList, list);
        }

        [TestMethod]
        public void TestGetSlotNumListWhereTheCarParkedEverWithFailure()
        {
            string PlateNumber = "KA-01-HH-1234";
            string Color = "White";
            string CarGUID = Guid.NewGuid().ToString();
            Car c = new Car
            {
                PlateNumber = PlateNumber,
                Color = Color,
                CarGUID = CarGUID,
                AllocatedParkingLot = 1,
                IsInParkingLot = true
            };
            Car c2 = new Car
            {
                PlateNumber = PlateNumber,
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 2,
                IsInParkingLot = true
            };
            Car c3 = new Car
            {
                PlateNumber = "KA-01-HH-2345",
                Color = CarColor.Blue.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 3,
                IsInParkingLot = true
            };
            Car c4 = new Car
            {
                PlateNumber = "KA-01-HH-3456",
                Color = CarColor.White.ToString(),
                CarGUID = CarGUID,
                AllocatedParkingLot = 2,
                IsInParkingLot = true
            };
            plms.DisplayParkingLotDictionary[1].DisplayParkingHistory.Add(c);
            plms.DisplayParkingLotDictionary[2].DisplayParkingHistory.Add(c2);
            plms.DisplayParkingLotDictionary[3].DisplayParkingHistory.Add(c3);
            plms.DisplayParkingLotDictionary[4].DisplayParkingHistory.Add(c4);
            List<int> ExpectedList = new List<int> { 1, 2 };

            var list = plms.GetSlotNumListWhereTheCarParkedEver("KA-01-HH-4567", out ResponseCode);

            Assert.AreEqual("P0016", ResponseCode);
            Assert.AreEqual(0, list.Count);
        }
    }
}
