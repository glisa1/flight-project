using FlightProject.Application.Models.DTOs;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetReservationByIdQuery : IRequest<ReservationDto>
{
    public int Id { get; init; }
}
