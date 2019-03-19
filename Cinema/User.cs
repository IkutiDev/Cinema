using System;
using System.Collections.Generic;

namespace Cinema
{
    public interface IUser
    {
        string Email { get; }
        string Password { get; }
        string Name { get; }
        string Surname { get; }
        List<IReservation> Reservations { get; }
        string ListReservations();
        string ShowReservation(int id);
        bool DeleteReservation(int id);
        void DeleteAllReservations();
        bool AddReservation(IReservation reservation);
    }
}