using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema;
namespace UnitTestProject1
{
    [TestClass]
    public class SeatTests
    {
        Seat seat;
        Movie movie;
        [TestInitialize]
        public void TestInitialize()
        {
            movie = new Movie("Test", "Test description", 1, 5, new DateTime(2018, 6, 10));
            seat = new Seat(1,15,movie);
        }
        public void TestCleanup()
        {
            movie = null;
            seat = null;
        }
    }
}
