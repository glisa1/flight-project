using FlightProject.Application.Models.Commands;
using FluentValidation;

namespace FlightProject.Application.Models.Validators.CommandValidators;

internal class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().MaximumLength(50);
    }
}
