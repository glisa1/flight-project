using FlightProject.Application.Models.Queries;
using FluentValidation;

namespace FlightProject.Application.Models.Validators.QueryValidators;

internal class GetPlaneByIdQueryValidator : AbstractValidator<GetPlaneByIdQuery>
{
    public GetPlaneByIdQueryValidator()
    {
        RuleFor(query => query.Id).NotEmpty().GreaterThan(0);
    }
}
