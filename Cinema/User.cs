using System;
using System.Collections.Generic;

namespace Cinema
{
    public interface IUser
    {
        string Email { get; }
        string Name { get; }
        string Surname { get; }
        List<IReservation> Reservations { get; }
        string ListReservations();
        string ShowReservation(int id);
        bool DeleteReservation(int id);
        void DeleteAllReservations();
        bool AddReservation(IReservation reservation);
        string ShowUserInfo();
    }
    public class User : IUser
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public List<IReservation> Reservations { get; private set; }
        public User(string email,string name,string surname)
        {
            Email = email;
            Name = name;
            Surname = surname;
            Reservations = new List<IReservation>();
        }
        public string ListReservations()
        {
            string list = "";
            if (Reservations.Count == 0)
            {
                return list;
            }
            else
            {
                foreach(IReservation r in Reservations)
                {
                    list += $"Movie: {r.Movie.GetInformation()}\n Ticket price: {r.TicketPrice}\n Seats:{r.SeatList()}";
                }
            }
            return list;
        }

        public string ShowReservation(int id)
        {
            if (ReservationExists(id))
            {
                IReservation r = Reservations[id];
                return $"Movie: {r.Movie.GetInformation()}\n Ticket price{r.TicketPrice}\n Seats:{r.SeatList()}";
            }
            else
            {
                return "This reservation doesn't exist";
            }
        }
        public string ShowUserInfo()
        {
            return $"Email:{Email} Name:{Name} Surname:{Surname}";
        }
        public bool DeleteReservation(int id)
        {
            if (ReservationExists(id))
            {
                Reservations.RemoveAt(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteAllReservations()
        {
            Reservations = new List<IReservation>();
        }

        public bool AddReservation(IReservation reservation)
        {
            if (reservation != null)
            {
                Reservations.Add(reservation);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ReservationExists(int id)
        {
            if(id <Reservations.Count && id >= 0)
            {
                return true;
            }
            return false;
        }
    }
}