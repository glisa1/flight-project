using FlightProject.Application.Models.Commands;
using FluentValidation;

namespace FlightProject.Application.Models.Validators.CommandValidators;

internal class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateFlightCommandValidator()
    {
        RuleFor(command => command.SourceCityId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.DestinationCityId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.PlaneId).NotEmpty().GreaterThan(0);

        RuleFor(command => command.Arrival).GreaterThan(command => command.Departure);

        RuleFor(command => command.Price).NotEmpty().GreaterThan(0);
    }
}
