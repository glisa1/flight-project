using FlightProject.Application.Models.DTOs;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetReservationByIdQuery : IRequest<Result<ReservationDto>>
{
    public int Id { get; init; }
}
