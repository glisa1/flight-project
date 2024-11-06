namespace FlightProject.WebApi.Models;

public sealed record CreateFlightDTO(int SourceId, int DestinationId, int PlaneId, DateTime Departure, double Price);

//public sealed class CreateFlightDTOValidator : AbstractValidator<CreateFlightDTO>
//{
//    public CreateFlightDTOValidator()
//    {
//        RuleFor(flight => flight.Price).NotEmpty().GreaterThan(0);
//        RuleFor(flight => flight.SourceId).GreaterThan(0);
//        RuleFor(flight => flight.DestinationId).GreaterThan(0);
//        RuleFor(flight => flight.PlaneId).GreaterThan(0);
//    }
//}
