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
        TimeSpan HowFarAwayIsScreening(); 
        string GetInformation();

    }
    public class Movie : IMovie
    {
        private DateTime _screeningDate;
        public string Title { get; private set; }

        public string Description { get; private set; }

        public int ScreeningRoom { get; private set; }

        public int NumberOfRows { get; private set; }

        public List<Seat> Seats { get; private set; }

        public DateTime ScreeningDate { get => _screeningDate; private set { if (value < DateTime.Now) { throw new ArgumentException("Screening date can't be in the past or at the time of entering the movie."); }_screeningDate=value; } }

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
                    Seats.Add(new Seat(i,j));
                }
            }
        }
        public string GetInformation()
        {
            return $"Title: {Title}, Description: {Description}, ScreeningRoom: {ScreeningRoom}, ScreeningDate {ScreeningDate}, Number of Seats {NumberOfRows * 20}";
        }

        public TimeSpan HowFarAwayIsScreening()
        {
            TimeSpan time;
            time = ScreeningDate - DateTime.Now;
            return time;
        }
    }
}