using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema;
namespace UnitTestProject1
{
    [TestClass]
    public class ReservationTests
    {
        User user;
        Movie movie;
        Reservation reservation;
        [TestInitialize]
        public void TestInitialize()
        {
            user = new User("email@email.com", "John", "Smith");
            movie = new Movie("Test", "Test description", 1, 5, new DateTime(2018, 6, 10));
            reservation = new Reservation(user,movie,30);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            user = null;
            movie = null;
            reservation = null;
        }
    }
}
