using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using FlightProject.WebApi.Extensions;
using FluentValidation;
using MediatR;

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
        application.MapGet("/plane/{id}", async (GetPlaneByIdQuery query, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(query, token);

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
            //var result = await dbContext.Planes.ToListAsync(token);

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
        application.MapPost("/plane", async (CreatePlaneCommand command, IMediator mediator, CancellationToken token) =>
        {
            try
            {
                await mediator.Send(command, token);

                return Results.Ok(command);
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
        .WithName("CreatePlane")
        .WithOpenApi();
    }

}
