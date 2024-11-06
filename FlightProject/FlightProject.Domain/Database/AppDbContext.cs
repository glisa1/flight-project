using FlightProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Domain.Database;

internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}
