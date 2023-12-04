using Cinema.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Interfaces
{
    public interface IDomainContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<ShowTime> Shows { get; set; }
        public DbSet<TheaterSeat> TheaterSeats { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}