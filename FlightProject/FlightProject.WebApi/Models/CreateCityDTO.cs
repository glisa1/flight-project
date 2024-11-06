namespace FlightProject.WebApi.Models;

public sealed record CreateCityDTO(string Name);

//public sealed class CreateCityDTOValidator : AbstractValidator<CreateCityDTO>
//{
//    public CreateCityDTOValidator()
//    {
//        RuleFor(city => city.Name).NotEmpty().MaximumLength(50);
//    }
//}
