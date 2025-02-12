using FlightProject.Application.Models.DTOs;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetFlightByIdQuery : IRequest<Result<FlightDto>>
{
    public int FlightId { get; init; }
}
