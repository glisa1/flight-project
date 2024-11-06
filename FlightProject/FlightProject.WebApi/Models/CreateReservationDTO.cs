namespace FlightProject.WebApi.Models;

public sealed record CreateReservationDTO(int FlightId, int UserId);

//public sealed class CreateReservationDTOValidator : AbstractValidator<CreateReservationDTO>
//{
//    public CreateReservationDTOValidator()
//    {
//        RuleFor(reservation => reservation.FlightId).NotEmpty().GreaterThan(0);
//        RuleFor(reservation => reservation.UserId).NotEmpty().GreaterThan(0);
//    }
//}
