using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetCitiesQuery : IRequest<Result<IEnumerable<CityDto>>>
{
}
