using FlightProject.Application.Extensions;
using FlightProject.Application.Models;
using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Mappers;
using FlightProject.Application.Models.Queries;
using FlightProject.Application.Models.Validators.CommandValidators;
using FlightProject.Application.Models.Validators.QueryValidators;
using FlightProject.Domain.Models;
using FlightProject.Domain.Repository;
using FlightProject.Domain.Repository.Planes;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Services;

internal sealed class PlaneService(IPlaneRepository _repository) :
    IRequestHandler<GetPlanesQuery, Result<IEnumerable<PlaneDto>>>,
    IRequestHandler<GetPlaneByIdQuery, Result<PlaneDto>>,
    IRequestHandler<CreatePlaneCommand, Result>
{
    private readonly IRepository<Plane> repository = _repository;

    public async Task<Result<IEnumerable<PlaneDto>>> Handle(GetPlanesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(cancellationToken);

        return Result.Success(result.MapToDto());
    }

    public async Task<Result> Handle(CreatePlaneCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePlaneCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.ValidationFailure(validationResult.Errors.GetErrors());
        }

        var model = new Plane
        {
            Name = request.Name,
            NumberOfSeats = request.NumberOfSeats,
        };

        await repository.AddAsync(model, cancellationToken);

        return Result.Success();
    }

    public async Task<Result<PlaneDto>> Handle(GetPlaneByIdQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetPlaneByIdQueryValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.ValidationFailure<PlaneDto>(default, validationResult.Errors.GetErrors());
        }

        var result = await repository.GetAsync(request.Id, cancellationToken);

        return Result.Success(result.MapToDto());
    }
}
