using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public interface ISeat
    {
        int SeatNumber { get; }
        int RowNumber { get; }
        IMovie Movie { get; }
        bool IsTaken { get; }
    }
    public class Seat : ISeat
    {
        public int SeatNumber { get; private set; }

        public int RowNumber { get; private set; }

        public IMovie Movie { get; private set; }

        public bool IsTaken { get; private set; }
        public Seat(int rowNumber, int seatNumber,IMovie movie)
        {
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            Movie = movie;
            IsTaken = false;
        }
    }
}
