using FlightProject.WebApi.Endpoints;

namespace FlightProject.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static void MapGetEndpoints(this WebApplication app)
    {
        app.MapCityEndpoints();
        app.MapPlaneEndpoints();
        app.MapReservationEndpoints();
        app.MapFlightEndpoints();
    }
}
