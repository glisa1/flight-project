using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using FlightProject.WebApi.Extensions;
using FluentValidation;
using MediatR;

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
        application.MapGet("/flight/{id}", async (GetFlightByIdQuery query, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(query, token);

            return Results.Ok(result);
        })
        .WithName("GetFlightById")
        .WithOpenApi();
    }

    private static void MapGetAllFlights(this WebApplication application)
    {
        application.MapGet("/flights", async (GetAllFlightsQuery query, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(query, token);

            return Results.Ok(result);
        })
        .WithName("GetAllFlights")
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
        application.MapPost("/flight", async (CreateFlightCommand command, IMediator mediator, CancellationToken token) =>
        {
            try
            {
                await mediator.Send(command, token);

                return Results.Ok();

            }
            catch (ValidationException ve)
            {
                return Results.ValidationProblem(ve.AsProblemsDictionary());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithName("CreateFlight")
        .WithOpenApi();
    }

    #endregion
}
