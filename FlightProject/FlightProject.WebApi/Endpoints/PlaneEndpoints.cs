using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.WebApi.Endpoints;

public static class PlaneEndpoints
{
    public static void MapPlaneEndpoints(this WebApplication application)
    {
        MapPlaneGetEndpoints(application);
        MapPlanePostEndpoints(application);
    }

    private static void MapPlaneGetEndpoints(this WebApplication application)
    {
        MapGetPlaneById(application);
        MapGetAllPlanes(application);
    }

    private static void MapGetPlaneById(this WebApplication application)
    {
        application.MapGet("/plane/{id}", async (int id, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(new GetPlaneByIdQuery { Id = id }, token);

            return Results.Ok(result);
        })
        .WithName("GetPlaneById")
        .WithOpenApi();
    }

    private static void MapGetAllPlanes(this WebApplication application)
    {
        application.MapGet("/planes", async (IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(new GetPlanesQuery(), token);

            return Results.Ok(result);
        })
        .WithName("GetAllPlanes")
        .WithOpenApi();
    }

    private static void MapPlanePostEndpoints(this WebApplication application)
    {
        MapCreatePlane(application);
    }

    private static void MapCreatePlane(this WebApplication application)
    {
        application.MapPost("/plane", async ([FromBody] CreatePlaneCommand command, IMediator mediator, CancellationToken token) =>
        {
            try
            {
                await mediator.Send(command, token);

                return Results.Ok(command);
            }
            //catch (ValidationException ve)
            //{
            //    return Results.ValidationProblem(ve.AsProblemsDictionary());
            //}
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithName("CreatePlane")
        .WithOpenApi();
    }

}
