using FlightProject.Application.Models;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Application.Models.Validators.CommandValidators;
using FlightProject.Application.Models.Validators.QueryValidators;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository.Flights;
using FluentValidation;
using MediatR;

namespace FlightProject.Application.Services;

internal class FlightService(IFlightRepository flightRepository)
    :
    IRequestHandler<GetAllFlightsQuery, IEnumerable<FlightDto>>,
    IRequestHandler<GetFlightByIdQuery, FlightDto>,
    IRequestHandler<CreateFlightCommand>
{
    private readonly IFlightRepository _flightRepository = flightRepository;

    public async Task<IEnumerable<FlightDto>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        var result = await _flightRepository.GetAllAsync(cancellationToken);

        return result.MapToDto();
    }

    public async Task<FlightDto> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetFlightByIdQueryValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var result = await _flightRepository.GetAsync(request.FlightId, cancellationToken);

        return result.MapToDto();
    }

    public async Task Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateFlightCommandValidator();

        await validator.ValidateAndThrowAsync(request, cancellationToken);

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
    }
}
