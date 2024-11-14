using FlightProject.Application.Models;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Application.Models.Validators.CommandValidators;
using FlightProject.Application.Models.Validators.QueryValidators;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository.Reservations;
using FluentValidation;
using MediatR;

namespace FlightProject.Application.Services;

internal class ReservationService(
    IReservationRepository _reservationRepository
    )
    :
    IRequestHandler<CreateReservationCommand>,
    IRequestHandler<GetAllUserReservationsQuery, IEnumerable<ReservationDto>>,
    IRequestHandler<GetReservationByIdQuery, ReservationDto>
{
    private readonly IReservationRepository reservationRepository = _reservationRepository;
    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateReservationCommandValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);

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
        var validator = new GetReservationByIdQueryValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var result = await reservationRepository.GetAsync(request.Id, cancellationToken);

        return result.MapToDto();
    }
}
