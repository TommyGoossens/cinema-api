using System.Diagnostics.CodeAnalysis;
using Cinema.Domain.Interfaces;
using Cinema.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure
{
    public class DomainContext : DbContext, IDomainContext
    {
        public DomainContext()
        {
        }

        public DomainContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<ShowTime> Shows { get; set; }
        public DbSet<TheaterSeat> TheaterSeats { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

