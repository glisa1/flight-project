using FlightProject.Application.Models.Commands;
using FluentValidation;

namespace FlightProject.Application.Models.Validators.CommandValidators;

internal class CreatePlaneCommandValidator : AbstractValidator<CreatePlaneCommand>
{
    public CreatePlaneCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().MaximumLength(50);
        RuleFor(command => command.NumberOfSeats).NotEmpty().GreaterThan(0);
    }
}
