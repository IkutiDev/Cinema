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
        public void TestCleanup()
        {
            movie = null;
        }
    }
}
