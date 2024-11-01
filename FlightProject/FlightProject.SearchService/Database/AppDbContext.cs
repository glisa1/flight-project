using FlightProject.SearchService.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.SearchService.Database;

public class AppDbContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
