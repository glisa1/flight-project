using FlightProject.Domain.Models;

namespace FlightProject.Application.Models.Mappers;

internal static class PlaneDtoMapper
{
    internal static IEnumerable<PlaneDto> MapToDto(this IEnumerable<Plane> planes)
    {
        ArgumentNullException.ThrowIfNull(planes, nameof(planes));

        return planes.Select(x => new PlaneDto(x.Id, x.Name, x.NumberOfSeats));
    }
}
