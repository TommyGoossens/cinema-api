using MediatR;
using Cinema.Domain.Models;
using Cinema.Domain.Interfaces;
using Cinema.Core.Application.Exceptions;

namespace Cinema.Application.Core.Commands.Reservations
{
    public record CreateReservationCommand(int ShowId, int SeatId, int UserId) : IRequest<SeatReservation>;
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, SeatReservation>
    {
        private IDomainContext domainContext;

        public CreateReservationCommandHandler(IDomainContext domainContext)
        {
            this.domainContext = domainContext;
        }

        public async Task<SeatReservation> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var (showId, seatId, userId) = request;
            var show = domainContext.Shows.FirstOrDefault(s => s.Id == showId);
            var showSeat = show!.FindReservation(seatId);
            if (showSeat == null)
            {
                showSeat = show.Theater.MakeReservation(showId, seatId, userId);
                domainContext.Theaters.Update(show.Theater);
                await domainContext.SaveChangesAsync(cancellationToken);
            }
            else if (showSeat.Status == SeatReservationStatus.InProgress) throw new SeatReservationInProgressException(show.Theater, showSeat.Seat, show);
            else if (showSeat.Status == SeatReservationStatus.Reserved) throw new SeatIsAlreadyReservedException(show.Theater, showSeat.Seat, show);
            return showSeat;
        }
    }
}