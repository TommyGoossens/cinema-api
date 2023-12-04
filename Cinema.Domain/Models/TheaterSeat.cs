using System.Globalization;

namespace Cinema.Domain.Models
{
    public class TheaterSeat
    {
        public int Id { get; set; }
        public int Row { get; private init; }
        public char SeatLetter { get; private init; }
        public string SeatNumber => $"{Row}{SeatLetter}";

        public TheaterSeat(int row, char seatLetter)
        {
            Row = row;
            SeatLetter = char.ToUpper(seatLetter, CultureInfo.InvariantCulture);
        }

    }
}

