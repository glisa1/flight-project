using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreateReservationCommand : IRequest
{
    public int FlightId { get; init; }
    public int UserId { get; init; }
}
