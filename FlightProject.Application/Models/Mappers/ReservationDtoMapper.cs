using FlightProject.Domain.Models;

namespace FlightProject.Application.Models.Mappers;

internal static class ReservationDtoMapper
{
    internal static IEnumerable<ReservationDto> MapToDto(this IEnumerable<Reservation> reservations)
    {
        ArgumentNullException.ThrowIfNull(reservations, nameof(reservations));

        return reservations.Select(reservation =>
        {
            return new ReservationDto
            (
                reservation.Flight.Id,
                reservation.Flight.Price,
                reservation.Flight.Departure,
                DateTime.UtcNow,//reservation.Flight.Arrival
                reservation.Flight.Source.Name,
                reservation.Flight.Destination.Name,
                reservation.Flight.Plane.Name
            );
        });
    }
}
