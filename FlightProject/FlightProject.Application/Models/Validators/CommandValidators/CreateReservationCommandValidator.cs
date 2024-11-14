using FlightProject.Application.Models.Commands;
using FluentValidation;

namespace FlightProject.Application.Models.Validators.CommandValidators;

internal class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(command => command.UserId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.FlightId).NotEmpty().GreaterThan(0);
    }
}
