using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema;
using Cinema.Fakes;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class ReservationTests
    {
        User user;
        Movie movie;
        Reservation reservation;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void TestInitialize()
        {
            user = new User("email@email.com", "John", "Smith");
            movie = new Movie("Test", "Test description", 1, 5, new DateTime(2019, 6, 10));
            reservation = new Reservation(user,movie,30);
        }
        [DeploymentItem("Cinema.UnitTestProject1\\SeatData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
"|DataDirectory|\\SeatData.csv", "SeatData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void AddOneSeatsViaCSV()
        {
            int rowNumber = int.Parse(TestContext.DataRow["row"].ToString());
            int seatNumber = int.Parse(TestContext.DataRow["seat"].ToString());
            Seat seat = new Seat(rowNumber, seatNumber);
            reservation.AddSeat(seat);
            Assert.AreEqual(seatNumber, reservation.Seats[0].SeatNumber);
        }
        [TestMethod]
        public void AddOneSeat()
        {
            var seat = new StubISeat()
            {
                RowNumberGet = () => { return 1; },
                SeatNumberGet = () => { return 1; }
            };
            reservation.AddSeat(seat);
            Assert.AreEqual(1, reservation.Seats[0].RowNumber);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                "Seat either can't exist or is already taken")]
        public void TooHighRowNumber()
        {
            var seat = new StubISeat()
            {
                RowNumberGet = () => { return 7; },
                SeatNumberGet = () => { return 1; }
            };
            reservation.AddSeat(seat);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Seat either can't exist or is already taken")]
        public void SeatAddedAlreadyTaken()
        {
            var seat = new StubISeat()
            {
                RowNumberGet = () => { return 1; },
                SeatNumberGet = () => { return 1; },
                IsTakenGet = () => { return true; }
            };
            reservation.AddSeat(seat);
        }
        [TestMethod]
        public void AddMultipleSeats()
        {
            List<ISeat> seats = new List<ISeat>();
            for(int i = 0; i < 10; i++)
            {
                var seat = new StubISeat()
                {
                    RowNumberGet = () => { return 1; },
                    SeatNumberGet = () => { return i; }
                };
                seats.Add(seat);
            }
            reservation.AddSeats(seats);
            Assert.AreEqual(10,reservation.Seats.Count);
        }
        [TestMethod]
        public void AddSeatThatIsNull()
        {
             reservation.AddSeat(null);
            Assert.AreEqual(0, reservation.Seats.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Seat either can't exist or doesn't exist in this reservation")]
        public void RemoveNullSeat()
        {

            reservation.RemoveSeat(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Seat either can't exist or doesn't exist in this reservation")]
        public void RemoveNonExistantSeat()
        {
            var seat = new StubISeat()
            {
                RowNumberGet = () => { return 1; },
                SeatNumberGet = () => { return 1; }
            };
            reservation.RemoveSeat(seat);
        }
        [TestMethod]
        public void RemoveSeatTest()
        {
            var seat = new StubISeat()
            {
                RowNumberGet = () => { return 1; },
                SeatNumberGet = () => { return 1; }
            };
            reservation.AddSeat(seat);
            reservation.RemoveSeat(seat);
            Assert.AreEqual(0, reservation.Seats.Count);
        }
        [TestMethod]
        public void SeatListEmpty()
        {
            string result = reservation.SeatList();
            StringAssert.Contains(result, "Test");
        }
        [TestMethod]
        public void SeatListTitle()
        {
            var seat = new StubISeat()
            {
                RowNumberGet = () => { return 1; },
                SeatNumberGet = () => { return 1; }
            };
            reservation.AddSeat(seat);
            string result = reservation.SeatList();
            StringAssert.Contains(result, "Test");
        }
        [TestMethod]
        public void SeatListTest()
        {
            var seat = new StubISeat()
            {
                RowNumberGet = () => { return 1; },
                SeatNumberGet = () => { return 1; }
            };
            reservation.AddSeat(seat);
            string result = reservation.SeatList();
            StringAssert.Contains(result, "Seat Number:1");
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
