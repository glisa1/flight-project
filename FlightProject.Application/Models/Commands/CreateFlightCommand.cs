﻿using MediatR;

namespace FlightProject.Application.Models.Commands;

public class CreateFlightCommand : IRequest
{
    public int PlaneId { get; init; }
    public int SourceCityId { get; init; }
    public int DestinationCityId { get; init; }
    public DateTime Departure { get; init; }
    public DateTime Arrival { get; init; }
    public double Price { get; init; }
}