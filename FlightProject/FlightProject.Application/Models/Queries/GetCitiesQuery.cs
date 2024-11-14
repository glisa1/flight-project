using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetCitiesQuery : IRequest<IEnumerable<CityDto>>
{
}
