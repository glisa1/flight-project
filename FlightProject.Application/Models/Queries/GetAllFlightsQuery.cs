using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetAllFlightsQuery : IRequest<IEnumerable<FlightDto>>
{
}
