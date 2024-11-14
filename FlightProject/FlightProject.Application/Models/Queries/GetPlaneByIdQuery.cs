using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetPlaneByIdQuery : IRequest<PlaneDto>
{
    public int Id { get; init; }
}
