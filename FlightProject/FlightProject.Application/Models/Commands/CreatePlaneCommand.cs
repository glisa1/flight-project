using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreatePlaneCommand : IRequest<Result>
{
    public string Name { get; init; }
    public int NumberOfSeats { get; init; }
}
