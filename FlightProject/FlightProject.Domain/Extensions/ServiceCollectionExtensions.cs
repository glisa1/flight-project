using FlightProject.Domain.Database;
using FlightProject.Domain.Repository.Cities;
using FlightProject.Domain.Repository.Flights;
using FlightProject.Domain.Repository.Planes;
using FlightProject.Domain.Repository.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlightProject.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDomainServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseNpgsql(connectionString);
        });

        //services.AddIdentityApiEndpoints<IdentityUser>()
        //    .AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IPlaneRepository, PlaneRepository>();
    }
}
