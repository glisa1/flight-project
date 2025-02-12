using FlightProject.Application.Models.DTOs;
using FlightProject.Domain.Models;

namespace FlightProject.Application.Models.Mappers;

internal static class ReservationDtoMapper
{
    internal static IEnumerable<ReservationDto> MapToDto(this IEnumerable<Reservation> reservations)
    {
        ArgumentNullException.ThrowIfNull(reservations, nameof(reservations));

        return reservations.Select(reservation => reservation.MapToDto());
    }

    internal static ReservationDto MapToDto(this Reservation reservation)
    {
        ArgumentNullException.ThrowIfNull(reservation, nameof(reservation));

        return new ReservationDto
            (
                reservation.Flight.Id,
                reservation.Flight.Price,
                reservation.Flight.Departure,
                reservation.Flight.Arrival,
                reservation.Flight.Source.Name,
                reservation.Flight.Destination.Name,
                reservation.Flight.Plane.Name
            );
    }
}
