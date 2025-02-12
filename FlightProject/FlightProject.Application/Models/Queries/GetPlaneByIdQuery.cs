using FlightProject.Application.Models.DTOs;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetPlaneByIdQuery : IRequest<Result<PlaneDto>>
{
    public int Id { get; init; }
}
