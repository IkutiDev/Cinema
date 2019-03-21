using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema;
namespace UnitTestProject1
{
    [TestClass]
    public class SeatTests
    {
        Seat seat;
        [TestInitialize]
        public void TestInitialize()
        {
            seat = new Seat(1,15);
        }
        [TestMethod]
        public void GetInformationSeat()
        {
            string result = seat.GetInformation();
            StringAssert.Contains(result,"Seat Number:15,");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
    "SeatNumber can't be higher than 20 or lower than 0.")]
        public void WrongSeatNumber()
        {
            seat = new Seat(1,25);
        }
        public void TestCleanup()
        {
            seat = null;
        }
    }
}
