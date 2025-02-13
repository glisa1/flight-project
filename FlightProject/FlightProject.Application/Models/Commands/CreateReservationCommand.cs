using FlightProject.Application.Models.DTOs;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreateReservationCommand : IRequest<Result<ReservationCreatedDto>>
{
    public int FlightId { get; init; }
    public int UserId { get; init; }
}
