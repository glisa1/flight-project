using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetPlanesQuery : IRequest<IEnumerable<PlaneDto>>
{
}
