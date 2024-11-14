using FlightProject.Application.Models.Queries;
using FluentValidation;

namespace FlightProject.Application.Models.Validators.QueryValidators;

internal class GetFlightByIdQueryValidator : AbstractValidator<GetFlightByIdQuery>
{
    public GetFlightByIdQueryValidator()
    {
        RuleFor(query => query.FlightId).NotEmpty().GreaterThan(0);
    }
}
