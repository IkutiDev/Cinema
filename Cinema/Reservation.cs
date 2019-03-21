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
        void AddSeats(List<ISeat> seats);
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
            if (seat == null)
            {
                return;
            }
            if(SeatExists(seat) && SeatNotTaken(seat))
            {
                seat.TakeSeat();
                Seats.Add(seat);
            }
            else
            {
                throw new ArgumentException("Seat either can't exist or is already taken");
            }
        }

        public void RemoveSeat(ISeat seat)
        {
            if (seat == null)
            {
                throw new ArgumentException("Seat either can't exist or doesn't exist in this reservation");
            }
            if (SeatExists(seat) && SeatExistsInList(seat))
            {
                Seats.Remove(seat);
            }
            else
            {
                throw new ArgumentException("Seat either can't exist or doesn't exist in this reservation");
            }
        }

        public string SeatList()
        {
            string list = $"Movie:{Movie.Title}\n";
            if (Seats.Count == 0)
            {
                return list;
            }
            else
            {
                foreach (ISeat s in Seats)
                {
                    list += $"Row Number:{s.RowNumber}, Seat Number:{s.SeatNumber}\n";
                }
                return list;
            }

        }

        public void AddSeats(List<ISeat> seats)
        {
            foreach(ISeat s in seats)
            {
                AddSeat(s);
            }
        }
        private bool SeatExists(ISeat seat)
        {
            if(seat.RowNumber>0 && seat.RowNumber < Movie.NumberOfRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool SeatNotTaken(ISeat seat)
        {
            if (seat.IsTaken)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool SeatExistsInList(ISeat seat)
        {
            foreach(ISeat s in Seats)
            {
                if(s.SeatNumber==seat.SeatNumber && s.RowNumber == seat.RowNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }
}