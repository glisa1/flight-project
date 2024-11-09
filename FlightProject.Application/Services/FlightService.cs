using FlightProject.Application.Models;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository.Cities;
using FlightProject.Domain.Repository.Flights;
using FlightProject.Domain.Repository.Planes;
using MediatR;

namespace FlightProject.Application.Services;

internal class FlightService(IFlightRepository flightRepository, IPlaneRepository planeRepository, ICityRepository cityRepository)
    :
    IRequestHandler<GetAllFlightsQuery, IEnumerable<FlightDto>>,
    IRequestHandler<GetFlightByIdQuery, FlightDto>,
    IRequestHandler<CreateFlightCommand>
{
    private readonly IFlightRepository _flightRepository = flightRepository;
    private readonly IPlaneRepository _planeRepository = planeRepository;
    private readonly ICityRepository _cityRepository = cityRepository;

    public async Task<IEnumerable<FlightDto>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        var result = await _flightRepository.GetAllAsync(cancellationToken);

        return result.MapToDto();
    }

    public async Task<FlightDto> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _flightRepository.GetAsync(request.FlightId, cancellationToken);

        return result.MapToDto();
    }

    public async Task Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var plane = await _planeRepository.GetAsync(request.PlaneId, cancellationToken);
        ArgumentNullException.ThrowIfNull(plane, nameof(plane));

        var sourceCity = await _cityRepository.GetAsync(request.SourceCityId, cancellationToken);
        ArgumentNullException.ThrowIfNull(sourceCity, nameof(sourceCity));

        var destinationCity = await _cityRepository.GetAsync(request.DestinationCityId, cancellationToken);
        ArgumentNullException.ThrowIfNull(destinationCity, nameof(destinationCity));

        var model = new Flight
        {
            Arrival = request.Arrival,
            Departure = request.Departure,
            Destination = destinationCity,
            Plane = plane,
            Source = sourceCity,
            Price = request.Price,
        };

        await _flightRepository.AddAsync(model, cancellationToken);
    }
}
