using FlightProject.Application.Models;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository;
using MediatR;

namespace FlightProject.Application.Services;

internal class PlaneService(IRepository<Plane> _repository) : 
    IRequestHandler<GetPlanesQuery, IEnumerable<PlaneDto>>,
    IRequestHandler<CreatePlaneCommand>
{
    private readonly IRepository<Plane> repository = _repository;

    public async Task<IEnumerable<PlaneDto>> Handle(GetPlanesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(cancellationToken);

        return result.MapToDto();
    }

    public async Task Handle(CreatePlaneCommand request, CancellationToken cancellationToken)
    {
        var model = new Plane
        {
            Name = request.Name,
            NumberOfSeats = request.NumberOfSeats,
        };

        await repository.AddAsync(model, cancellationToken);
    }
}
