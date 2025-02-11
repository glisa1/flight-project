using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetPlanesQuery : IRequest<Result<IEnumerable<PlaneDto>>>
{
}
