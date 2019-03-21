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
        bool IsTaken { get; }
    }
    public class Seat : ISeat
    {
        private int _seatNumber;
        public int SeatNumber {
            get => _seatNumber;
            private set
            {
                if (value > 20)
                {
                    throw new ArgumentException("SeatNumber can't be higher than 20 or lower than 0.");
                }
                if (value < 0)
                {
                    throw new ArgumentException("SeatNumber can't be higher than 20 or lower than 0.");
                } _seatNumber = value; }
        }

        public int RowNumber { get; private set; }


        public bool IsTaken { get; private set; }
        public Seat(int rowNumber, int seatNumber)
        {
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            IsTaken = false;
        }
        public string GetInformation()
        {
            string result = $"Seat Number:{SeatNumber}, Row Number:{RowNumber}, Seat is ";
            if (IsTaken)
            {
                result += "taken.";
            }
            else
            {
                result += "not taken.";
            }
            return result;
        } 
    }
}
