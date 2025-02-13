using FlightProject.Application.Extensions;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.DTOs;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Application.Models.Validators.CommandValidators;
using FlightProject.Application.Models.Validators.QueryValidators;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository.Flights;
using FlightProject.Domain.Repository.Reservations;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Services;

internal sealed class ReservationService(
    IReservationRepository _reservationRepository,
    IFlightRepository _flightRepository
    )
    :
    IRequestHandler<CreateReservationCommand, Result<ReservationCreatedDto>>,
    IRequestHandler<GetAllUserReservationsQuery, Result<IEnumerable<ReservationDto>>>,
    IRequestHandler<GetReservationByIdQuery, Result<ReservationDto>>
{
    private readonly IReservationRepository reservationRepository = _reservationRepository;
    private readonly IFlightRepository flightRepository = _flightRepository;
    public async Task<Result<ReservationCreatedDto>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateReservationCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.ValidationFailure<ReservationCreatedDto>(default, validationResult.Errors.MapValidationFailuresToErrors());
        }

        var flight = await flightRepository.GetAsync(request.FlightId, cancellationToken);

        if (flight is null)
        {
            return Result.Failure<ReservationCreatedDto>(Error.NotFound("Reservation.Flight", "Flight not found."));
        }

        var model = new Reservation
        {
            FlightId = request.FlightId,
            UserId = request.UserId,
        };

        await reservationRepository.AddAsync(model, cancellationToken);


        return Result.Success(model.MapToCreatedDto());
    }

    public async Task<Result<IEnumerable<ReservationDto>>> Handle(GetAllUserReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await reservationRepository.GetAllReservationsForUserAsync(request.UserId, cancellationToken);

        return Result.Success(reservations.MapToDto());
    }

    public async Task<Result<ReservationDto>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetReservationByIdQueryValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.ValidationFailure<ReservationDto>(default, validationResult.Errors.MapValidationFailuresToErrors());
        }

        var result = await reservationRepository.GetAsync(request.Id, cancellationToken);

        if (result is null)
        {
            return Result.Failure<ReservationDto>(Error.NotFound("Reservation.Id", "Reservation not found."));
        }

        return Result.Success(result.MapToDto());
    }
}
