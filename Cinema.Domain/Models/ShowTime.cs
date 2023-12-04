namespace Cinema.Domain.Models
{
    public class ShowTime
    {
        public int Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public Movie Movie { get; private set; }
        public int MovieId { get; private set; }
        public Theater Theater { get; private set; }
        public int TheaterId { get; private set; }
        private ICollection<SeatReservation> SeatReservations { get; set; }

        public ShowTime(DateTime startTime, DateTime endTime, int movieId, int theaterId)
        {
            StartTime = startTime;
            EndTime = endTime;
            MovieId = movieId;
            TheaterId = theaterId;
        }

        public SeatReservation? FindReservation(int seatId)
        {
            SeatReservations ??= new List<SeatReservation>();
            return SeatReservations.FirstOrDefault(r => r.SeatId == seatId);
        }

        internal SeatReservation StartReservation(int seatId, int userId)
        {
            SeatReservations ??= new List<SeatReservation>();
            var reservation = new SeatReservation(this.Id, seatId, userId, SeatReservationStatus.InProgress);
            SeatReservations.Add(reservation);
            return reservation;
        }

        internal IEnumerable<SeatReservation> GetAllReservedSeats()
        {
            SeatReservations ??= new List<SeatReservation>();
            return SeatReservations;
        }
    }
}

