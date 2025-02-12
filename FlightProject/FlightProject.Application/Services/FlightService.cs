using FlightProject.Application.Extensions;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.DTOs;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Application.Models.Validators.CommandValidators;
using FlightProject.Application.Models.Validators.QueryValidators;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository.Cities;
using FlightProject.Domain.Repository.Flights;
using FlightProject.Domain.Repository.Planes;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Services;

internal sealed class FlightService(
    IFlightRepository flightRepository,
    ICityRepository cityRepository,
    IPlaneRepository planeRepository
    )
    :
    IRequestHandler<GetAllFlightsQuery, Result<IEnumerable<FlightDto>>>,
    IRequestHandler<GetFlightByIdQuery, Result<FlightDto>>,
    IRequestHandler<CreateFlightCommand, Result<FlightCreatedDto>>
{
    private readonly IFlightRepository _flightRepository = flightRepository;
    private readonly ICityRepository _cityRepository = cityRepository;
    private readonly IPlaneRepository _planeRepository = planeRepository;

    public async Task<Result<IEnumerable<FlightDto>>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        var result = await _flightRepository.GetAllAsync(cancellationToken);

        return Result.Success(result.MapToDto());
    }

    public async Task<Result<FlightDto>> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetFlightByIdQueryValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.ValidationFailure<FlightDto>(default, validationResult.Errors.MapValidationFailuresToErrors());
        }

        var result = await _flightRepository.GetAsync(request.FlightId, cancellationToken);

        return Result.Success(result.MapToDto());
    }

    public async Task<Result<FlightCreatedDto>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateFlightCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.ValidationFailure<FlightCreatedDto>(default, validationResult.Errors.MapValidationFailuresToErrors());
        }

        var plane = await _planeRepository.GetAsync(request.PlaneId, cancellationToken);

        if (plane is null)
        {
            return Result.Failure<FlightCreatedDto>(Error.NotFound("Flight.PlaneId", "Plane not found"));
        }

        var sourceCity = await _cityRepository.GetAsync(request.SourceCityId, cancellationToken);

        if (sourceCity is null)
        {
            return Result.Failure<FlightCreatedDto>(Error.NotFound("Flight.SourceCityId", "Source city not found"));
        }

        var destinationCity = await _cityRepository.GetAsync(request.DestinationCityId, cancellationToken);

        if (destinationCity is null)
        {
            return Result.Failure<FlightCreatedDto>(Error.NotFound("Flight.DestinationCityId", "Destination city not found"));
        }

        var model = new Flight
        {
            Arrival = request.Arrival,
            Departure = request.Departure,
            DestinationId = request.DestinationCityId,
            PlaneId = request.PlaneId,
            SourceId = request.SourceCityId,
            Price = request.Price,
        };

        await _flightRepository.AddAsync(model, cancellationToken);

        return Result.Success(model.MapToCreatedDto());
    }
}
