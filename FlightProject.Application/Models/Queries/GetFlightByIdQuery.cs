using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetFlightByIdQuery : IRequest<FlightDto>
{
    public int FlightId { get; init; }
}
