using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema;
using Cinema.Fakes;

namespace UnitTestProject1
{
    [TestClass]
    public class UserTests
    {
        User user;
        [TestInitialize]
        public void TestInitialize()
        {
            user = new User("email@email.com", "John","Smith");
        }
        [TestMethod]
        public void ShowUserInfo()
        {
            string result;
            result = user.ShowUserInfo();
            StringAssert.Contains(result,"John");
        }
        [TestMethod]
        public void EmptyReservationList()
        {
            string result = user.ListReservations();
            Assert.AreEqual("", result);
        }
        [TestMethod]
        public void ReservationList()
        {
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2018, 6, 10));
            var reservation = new StubIReservation()
            {
                MovieGet = () => { return movie; }
            };
            user.AddReservation(reservation);
            string result = user.ListReservations();
            StringAssert.Contains(result,"TestTitle");
        }
        [TestMethod]
        public void SelectedReservationDoesntExist()
        {
            string result = user.ShowReservation(0);
            StringAssert.Contains(result, "This reservation doesn't exist");
        }
        [TestMethod]
        public void SelectedReservationExists()
        {
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2018, 6, 10));
            var reservation = new StubIReservation()
            {
                MovieGet = () => { return movie; }
            };
            user.AddReservation(reservation);
            string result = user.ShowReservation(0);
            StringAssert.Contains(result, "TestTitle");
        }
        [TestMethod]
        public void RemoveWhenDoesntExist()
        {
            user.
        }
        public void TestCleanup()
        {
            user = null;
        }
    }
}
