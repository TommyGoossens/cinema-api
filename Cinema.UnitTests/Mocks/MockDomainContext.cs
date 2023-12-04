using System.Diagnostics.CodeAnalysis;
using Cinema.Domain.Interfaces;
using Cinema.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.UnitTests;

public class MockDomainContext : DbContext, IDomainContext
{

    public MockDomainContext([NotNull] DbContextOptions options) : base(options)
    {
    }

    public MockDomainContext() : this(
        new DbContextOptionsBuilder<MockDomainContext>()
        .UseInMemoryDatabase(Guid.NewGuid()
        .ToString())
        .Options)
    {

    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<ShowTime> Shows { get; set; }
    public DbSet<TheaterSeat> TheaterSeats { get; set; }
    public DbSet<SeatReservation> SeatReservations { get; set; }
    public DbSet<User> Users { get; set; }


}
