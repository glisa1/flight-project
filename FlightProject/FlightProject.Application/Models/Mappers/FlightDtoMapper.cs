using FlightProject.Domain.Models;

namespace FlightProject.Application.Models.Mappers;

internal static class FlightDtoMapper
{
    internal static IEnumerable<FlightDto> MapToDto(this IEnumerable<Flight> flights)
    {
        ArgumentNullException.ThrowIfNull(flights, nameof(flights));

        return flights.Select(flight => flight.MapToDto());
    }

    internal static FlightDto MapToDto(this Flight flight)
    {
        ArgumentNullException.ThrowIfNull(flight, nameof(flight));

        return new FlightDto
            (
                flight.Id,
                flight.Price,
                flight.Departure,
                flight.Arrival,
                flight.Source.Name,
                flight.Destination.Name,
                flight.Plane.NumberOfSeats
            );
    }
}
