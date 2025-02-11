using FlightProject.Application.Extensions;
using FlightProject.Application.Models;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Application.Models.Validators.CommandValidators;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository;
using FlightProject.Domain.Repository.Cities;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Services;

internal sealed class CityService(ICityRepository repository) :
    IRequestHandler<GetCitiesQuery, Result<IEnumerable<CityDto>>>,
    IRequestHandler<CreateCityCommand, Result<City>>
{
    private readonly IRepository<City> _repository = repository;

    public async Task<Result<City>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCityCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.ValidationFailure<City>(default, validationResult.Errors.GetErrors());
        }

        var newCity = new City { Name = request.Name };

        await _repository.AddAsync(newCity, cancellationToken);

        return Result.Success(newCity);
    }

    async Task<Result<IEnumerable<CityDto>>> IRequestHandler<GetCitiesQuery, Result<IEnumerable<CityDto>>>.Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(cancellationToken);

        return Result.Success(result.MapToDto());
    }
}
