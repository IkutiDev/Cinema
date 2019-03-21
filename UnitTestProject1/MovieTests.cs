using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema;
namespace UnitTestProject1
{
    [TestClass]
    public class MovieTests
    {
        Movie movie;
        [TestInitialize]
        public void TestInitialize()
        {
            movie = new Movie("Test", "Test description", 1,5, new DateTime(2019, 6, 10));
        }
        [TestMethod]
        public void ShowInfo()
        {
            string result = movie.GetInformation();
            StringAssert.Contains(result,"Title: Test");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Screening date can't be in the past or at the time of entering the movie.")]
        public void WrongDate()
        {
            Movie movie = new Movie("Test","Test",1,5,new DateTime(2017,1,2));
        }
        [TestMethod]
        public void TimeDifference()
        {
            TimeSpan time =movie.HowFarAwayIsScreening();
            Assert.AreEqual(movie.ScreeningDate-DateTime.Now,time);
        }
        public void TestCleanup()
        {
            movie = null;
        }
    }
}
