using Cinema.Domain.Interfaces;

namespace Cinema.Domain.Models
{
    public class Theater : IAggregateRoot
    {
        public int Id { get; set; }
        public int TheaterNumber { get; set; }
        public ICollection<TheaterSeat> Seats { get; set; }
        public ICollection<ShowTime> Shows { get; set; }

        public Theater CreateShow(DateTime startTime, DateTime endTime, int movieId)
        {
            var showTime = new ShowTime(startTime, endTime, movieId, this.Id);
            Shows ??= new List<ShowTime>();
            Shows.Add(showTime);
            return this;
        }

        public Theater AddSeats(params TheaterSeat[] seats)
        {
            Seats ??= new List<TheaterSeat>();
            foreach (var s in seats) Seats.Add(s); // TODO Seat Validation
            return this;
        }

        public IEnumerable<TheaterSeat> GetAvailableSeats(ShowTime show)
        {
            var reservedSeats = show.GetAllReservedSeats();
            var availableSeats = Seats.Except(reservedSeats.Select(r => r.Seat));
            return availableSeats;
        }

        public SeatReservation MakeReservation(int showId, int seatId, int userId)
        {
            Shows ??= new List<ShowTime>();
            var show = Shows.FirstOrDefault(s => s.Id == showId);
            return show!.StartReservation(seatId, userId);
        }
    }
}

