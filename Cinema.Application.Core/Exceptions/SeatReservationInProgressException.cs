using System;
using Cinema.Domain.Models;

namespace Cinema.Core.Application.Exceptions;

public class SeatReservationInProgressException : Exception
{
    public SeatReservationInProgressException(Theater theater, TheaterSeat seat, ShowTime show) :
        base($"Reservation for this seat ({seat}) in theater ({theater}) for show ({show}) is already in progress for a different user.")
    {
    }

}

