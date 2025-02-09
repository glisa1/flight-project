using FlightProject.Domain.Models;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreateCityCommand : IRequest<Result<City>>
{
    public string? Name { get; init; }
}
