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
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2019, 6, 10));
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
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2019, 6, 10));
            var reservation = new StubIReservation()
            {
                MovieGet = () => { return movie; }
            };
            user.AddReservation(reservation);
            string result = user.ShowReservation(0);
            StringAssert.Contains(result, "TestTitle");
        }
        [TestMethod]
        public void AddReservation()
        {
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2019, 6, 10));
            var reservation = new StubIReservation()
            {
                MovieGet = () => { return movie; }
            };
            user.AddReservation(reservation);
            Assert.AreEqual("Test description",user.Reservations[0].Movie.Description);
        }
        [TestMethod]
        public void AddReservationReturnsTrue()
        {
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2019, 6, 10));
            var reservation = new StubIReservation()
            {
                MovieGet = () => { return movie; }
            };
            bool result = user.AddReservation(reservation);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddReservationNull()
        {
            bool result = user.AddReservation(null);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void RemoveReservation()
        {
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2019, 6, 10));
            var reservation = new StubIReservation()
            {
                MovieGet = () => { return movie; }
            };
            user.AddReservation(reservation);
            user.DeleteReservation(0);
            Assert.AreEqual(0,user.Reservations.Count);
        }
        [TestMethod]
        public void RemoveReservationWrongIndex()
        {
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2019, 6, 10));
            var reservation = new StubIReservation()
            {
                MovieGet = () => { return movie; }
            };
            user.AddReservation(reservation);
            user.DeleteReservation(10);
            Assert.AreEqual("TestTitle",user.Reservations[0].Movie.Title);
        }
        [TestMethod]
        public void RemoveReservationTrue()
        {
            Movie movie = new Movie("TestTitle", "Test description", 1, 5, new DateTime(2019, 6, 10));
            var reservation = new StubIReservation()
            {
                MovieGet = () => { return movie; }
            };
            user.AddReservation(reservation);
            bool result = user.DeleteReservation(0);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void RemoveReservationFalse()
        {
            bool result =user.DeleteReservation(10);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void RemoveAllReservations()
        {
            for(int i = 0; i < 10; i++)
            {
                user.AddReservation(new StubIReservation());
            }
            user.DeleteAllReservations();
            Assert.AreEqual(0, user.Reservations.Count);
        }
        public void TestCleanup()
        {
            user = null;
        }
    }
}
