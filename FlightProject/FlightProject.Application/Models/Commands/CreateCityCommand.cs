using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreateCityCommand : IRequest
{
    public string? Name { get; init; }
}
