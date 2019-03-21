using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema
{
    public interface IReservation
    {
        IUser User { get; }
        List<ISeat> Seats { get; }
        IMovie Movie { get; }
        decimal TicketPrice { get; }
        void AddSeat(ISeat seat);
        void AddSeats(List<ISeat> seat);
        void RemoveSeat(ISeat seat);
        string SeatList();


    }
    public class Reservation : IReservation
    {
        public IUser User { get; private set; }
        public IMovie Movie { get; private set; }
        public List<ISeat> Seats { get; private set; }

        public decimal TicketPrice { get; private set; }
        public Reservation(IUser user, IMovie movie, decimal ticketPrice)
        {
            User = user;
            Movie = movie;
            TicketPrice = ticketPrice;
            Seats = new List<ISeat>();
        }
        public void AddSeat(ISeat seat)
        {
            //if movie is right
            //if row is okay
            //if number of seat is okay
            //add seat
        }

        public void RemoveSeat(ISeat seat)
        {
            //if movie is right
            //if row is okay
            //if number of seat is okay
            //remove seat
        }

        public string SeatList()
        {
            throw new NotImplementedException();
        }

        public void AddSeats(List<ISeat> seat)
        {
            throw new NotImplementedException();
        }
    }
}