using FlightProject.Application.Models.DTOs;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreateCityCommand : IRequest<Result<CityDto>>
{
    public string? Name { get; init; }
}
