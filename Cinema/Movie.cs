using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema
{
    public interface IMovie
    {
        string Title { get; }
        string Description { get; }
        int ScreeningRoom { get; }
        int NumberOfRows { get; }
        List<Seat> Seats { get; }
        DateTime ScreeningDate { get; }
        string GetInformation();

    }
    public class Movie : IMovie
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public int ScreeningRoom { get; private set; }

        public int NumberOfRows { get; private set; }

        public List<Seat> Seats { get; private set; }

        public DateTime ScreeningDate { get; private set; }

        public Movie(string title, string description, int screeningRoom,int numberOfRows, DateTime screeningDate)
        {
            Title = title;
            Description = description;
            ScreeningRoom = screeningRoom;
            NumberOfRows = numberOfRows;
            ScreeningDate = screeningDate;
            Seats = new List<Seat>();
            for(int i = 0; i < numberOfRows; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    Seats.Add(new Seat(i,j,this));
                }
            }
        }
        public string GetInformation()
        {
            return $"Title: {Title}, Description: {Description}, ScreeningRoom: {ScreeningRoom}, ScreeningDate {ScreeningDate}, Number of Seats {NumberOfRows * 20}";
        }
    }
}