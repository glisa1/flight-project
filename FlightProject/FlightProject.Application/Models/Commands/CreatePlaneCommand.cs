using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreatePlaneCommand : IRequest
{
    public string Name { get; init; }
    public int NumberOfSeats { get; init; }
}
