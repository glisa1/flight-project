namespace FlightProject.WebApi.Models;

public sealed record CreatePlaneDTO(string Name, int NumberOfSeats);

//public sealed class CreatePlaneDTOValidator : AbstractValidator<CreatePlaneDTO>
//{
//    public CreatePlaneDTOValidator()
//    {
//        RuleFor(plane => plane.Name).NotEmpty().MaximumLength(50);
//        RuleFor(plane => plane.NumberOfSeats).NotEmpty().GreaterThan(0);
//    }
//}