using FlightProject.Application.Models.DTOs;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetAllUserReservationsQuery : IRequest<Result<IEnumerable<ReservationDto>>>
{
    public int UserId { get; init; }
}
