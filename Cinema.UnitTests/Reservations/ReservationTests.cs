using Cinema.Application.Core.Commands.Reservations;
using Cinema.Core.Application.Exceptions;
using Cinema.Domain.Models;
using FluentAssertions;

namespace Cinema.UnitTests.Reservations
{
    public class ReservationTests
    {
        [Test]
        public async Task TwoUsersShouldBeAbleToMakeSeperateReservations()
        {
            var context = new MockDomainContext();
            var movie = new Movie(-1, "Movie", MovieGenre.Action ^ MovieGenre.Comedy, new DateOnly(), "Desc", new List<string>() { "Actor" });
            context.Add(movie);
            await context.SaveChangesAsync();

            var theater = new Theater();
            theater.AddSeats(new TheaterSeat(0, 'A'), new TheaterSeat(0, 'B'));
            theater.CreateShow(DateTime.Now, DateTime.Now.AddHours(1), movie.Id);
            context.Theaters.Add(theater);
            await context.SaveChangesAsync();

            var user1 = new User(1, "User 1");
            var user2 = new User(2, "User 2");

            context.Users.Add(user1);
            context.Users.Add(user2);
            await context.SaveChangesAsync();

            var show = theater.Shows.First();

            var createReservationCommandUser1 = new CreateReservationCommand(theater.Id, show.Id, user1.Id);
            var reservation = new CreateReservationCommandHandler(context).Handle(createReservationCommandUser1, CancellationToken.None);
            var createReservationCommandUser2 = new CreateReservationCommand(theater.Id, show.Id, user2.Id);
            Func<Task> act = async () => { await new CreateReservationCommandHandler(context).Handle(createReservationCommandUser2, CancellationToken.None); };
            await act.Should().ThrowAsync<SeatReservationInProgressException>();
        }
    }

}

