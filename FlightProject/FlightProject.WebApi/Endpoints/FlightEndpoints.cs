using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using FlightProject.WebApi.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.WebApi.Endpoints;

public static class FlightEndpoints
{
    public static void MapFlightEndpoints(this WebApplication application)
    {
        MapFlightGetEndpoints(application);
        MapFlightPostEndpoints(application);
    }

    #region Get

    private static void MapFlightGetEndpoints(this WebApplication application)
    {
        MapGetFlightById(application);
        MapGetAllFlights(application);
    }

    private static void MapGetFlightById(this WebApplication application)
    {
        application.MapGet("/flight/{id}", async (int id, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(new GetFlightByIdQuery { FlightId = id }, token);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("GetFlightById")
        .WithTags(Tags.Flight)
        .WithOpenApi();
    }

    private static void MapGetAllFlights(this WebApplication application)
    {
        application.MapGet("/flights", async (IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(new GetAllFlightsQuery(), token);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("GetAllFlights")
        .WithTags(Tags.Flight)
        .WithOpenApi();
    }

    #endregion

    #region Post

    private static void MapFlightPostEndpoints(this WebApplication application)
    {
        MapCreateFlight(application);
    }

    private static void MapCreateFlight(this WebApplication application)
    {
        application.MapPost("/flight", async ([FromBody] CreateFlightCommand command, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(command, token);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("CreateFlight")
        .WithTags(Tags.Flight)
        .WithOpenApi();
    }

    #endregion
}
