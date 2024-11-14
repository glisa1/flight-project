using FlightProject.Domain.Models;

namespace FlightProject.Application.Models.Mappers;

internal static class PlaneDtoMapper
{
    internal static IEnumerable<PlaneDto> MapToDto(this IEnumerable<Plane> planes)
    {
        ArgumentNullException.ThrowIfNull(planes, nameof(planes));

        return planes.Select(plane => plane.MapToDto());
    }

    internal static PlaneDto MapToDto(this Plane plane)
    {
        ArgumentNullException.ThrowIfNull(plane, nameof(plane));

        return new PlaneDto(plane.Id, plane.Name, plane.NumberOfSeats);
    }
}
