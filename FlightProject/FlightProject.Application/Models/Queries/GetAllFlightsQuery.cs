using FlightProject.Application.Models.DTOs;
using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Queries;

public class GetAllFlightsQuery : IRequest<Result<IEnumerable<FlightDto>>>
{
}
