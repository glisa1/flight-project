using FlightProject.Domain.Models;

namespace FlightProject.Application.Models.Mappers;

internal static class CityDtoMapper
{
    internal static IEnumerable<CityDto> MapToDto(this IEnumerable<City> citites)
    {
        ArgumentNullException.ThrowIfNull(citites, nameof(citites));

        return citites.Select(x => new CityDto(x.Id, x.Name));
    }
}
