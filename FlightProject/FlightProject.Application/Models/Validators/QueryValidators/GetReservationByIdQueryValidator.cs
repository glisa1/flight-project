using FlightProject.Application.Models.Queries;
using FluentValidation;

namespace FlightProject.Application.Models.Validators.QueryValidators;

internal class GetReservationByIdQueryValidator : AbstractValidator<GetReservationByIdQuery>
{
    public GetReservationByIdQueryValidator()
    {
        RuleFor(query => query.Id).NotEmpty().GreaterThan(0);
    }
}
