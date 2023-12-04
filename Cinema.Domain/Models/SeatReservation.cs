
using System.ComponentModel.DataAnnotations;

namespace Cinema.Domain.Models
{
    public enum SeatReservationStatus
    {
        InProgress = 0,
        Pending = 1,
        Reserved = 2
    }
    public class SeatReservation
    {
        [Key] public int Id { get; set; }
        public SeatReservationStatus Status { get; set; }
        public TheaterSeat Seat { get; set; }
        public int SeatId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ShowTime Show { get; set; }
        public int ShowId { get; set; }

        public SeatReservation(int showId, int seatId, int userId, SeatReservationStatus status)
        {
            ShowId = showId;
            SeatId = seatId;
            UserId = userId;
            Status = status;
        }
    }
}