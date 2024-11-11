using FlightProject.Application.Models.Queries;
using FluentValidation;

namespace FlightProject.Application.Models.Validators.QueryValidators;

internal class GetAllUserReservationsQueryValidator : AbstractValidator<GetAllUserReservationsQuery>
{
    public GetAllUserReservationsQueryValidator()
    {
        RuleFor(query => query.UserId).NotEmpty().GreaterThan(0);
    }
}
