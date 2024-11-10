using FlightProject.Application.Models;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository;
using FlightProject.Domain.Repository.Flights;
using FlightProject.Domain.Repository.Reservations;
using MediatR;

namespace FlightProject.Application.Services;

internal class ReservationService(
    IReservationRepository _reservationRepository,
    IFlightRepository _flightRepository
    )
    :
    IRequestHandler<CreateReservationCommand>,
    IRequestHandler<GetAllUserReservationsQuery, IEnumerable<ReservationDto>>,
    IRequestHandler<GetReservationByIdQuery, ReservationDto>
{
    private readonly IReservationRepository reservationRepository = _reservationRepository;
    private readonly IRepository<Flight> fligthRepository = _flightRepository;
    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var model = new Reservation
        {
            FlightId = request.FlightId,
            UserId = request.UserId,
        };

        await reservationRepository.AddAsync(model, cancellationToken);
    }

    public async Task<IEnumerable<ReservationDto>> Handle(GetAllUserReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await reservationRepository.GetAllReservationsForUserAsync(request.UserId, cancellationToken);

        return reservations.MapToDto();
    }

    public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await reservationRepository.GetAsync(request.Id, cancellationToken);

        return result.MapToDto();
    }
}
