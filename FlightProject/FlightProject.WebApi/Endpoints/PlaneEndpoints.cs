using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using FlightProject.WebApi.Extensions;
using FlightProject.WebApi.Models;
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

    #region Get

    private static void MapPlaneGetEndpoints(this WebApplication application)
    {
        MapGetPlaneById(application);
        MapGetAllPlanes(application);
    }

    private static void MapGetPlaneById(this WebApplication application)
    {
        application.MapGet("/plane/{id}", async (int id, CancellationToken token) =>
        {
            //var result = await dbContext.Planes.FindAsync([id], token);

            //if (result is null)
            //{
            //    return Results.NotFound();
            //}

            return Results.Ok(id);
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

    #endregion

    #region Post

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
                //CreatePlaneDTOValidator validator = new();

                //await validator.ValidateAndThrowAsync(planeDto, token);

                //var plane = new Plane
                //{
                //    Name = planeDto.Name,
                //    NumberOfSeats = planeDto.NumberOfSeats,
                //};

                //var result = await dbContext.Planes.AddAsync(plane, token);

                //if (result is null)
                //{
                //    return Results.Problem();
                //}

                //await dbContext.SaveChangesAsync(token);

                //return Results.Created(string.Empty, new { result.Entity.Id });

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

    #endregion
}
