using FlightProject.Application.Models.DTOs;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetAllUserReservationsQuery : IRequest<IEnumerable<ReservationDto>>
{
    public int UserId { get; init; }
}
