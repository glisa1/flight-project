using FlightProject.Application.Models.DTOs;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreatePlaneCommand : IRequest<Result<PlaneDto>>
{
    public string Name { get; init; }
    public int NumberOfSeats { get; init; }
}
