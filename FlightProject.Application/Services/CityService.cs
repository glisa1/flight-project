using FlightProject.Application.Models;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Application.Models.Validators.CommandValidators;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository;
using FlightProject.Domain.Repository.Cities;
using FluentValidation;
using MediatR;

namespace FlightProject.Application.Services;

internal class CityService(ICityRepository repository) :
    IRequestHandler<GetCitiesQuery, IEnumerable<CityDto>>,
    IRequestHandler<CreateCityCommand>
{
    private readonly IRepository<City> _repository = repository;

    public async Task Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCityCommandValidator();
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        await _repository.AddAsync(new City { Name = request.Name }, cancellationToken);
    }

    async Task<IEnumerable<CityDto>> IRequestHandler<GetCitiesQuery, IEnumerable<CityDto>>.Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(cancellationToken);

        return result.MapToDto();
    }
}
