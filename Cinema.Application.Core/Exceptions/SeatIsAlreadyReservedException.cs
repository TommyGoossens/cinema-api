using Cinema.Domain.Models;

namespace Cinema.Core.Application.Exceptions;

public class SeatIsAlreadyReservedException : Exception
{
    public SeatIsAlreadyReservedException(Theater theater, TheaterSeat seat, ShowTime show) :
        base($"Given Seat ({seat}) in theater ({theater}) for show ({show}) is already reserverd.")
    {
    }
}
