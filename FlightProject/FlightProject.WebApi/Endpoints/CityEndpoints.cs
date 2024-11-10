using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using FlightProject.WebApi.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.WebApi.Endpoints;

public static class CityEndpoints
{
    public static void MapCityEndpoints(this WebApplication application)
    {
        MapCityGetEndpoints(application);
        MapCityPostEndpoints(application);
    }

    private static void MapCityGetEndpoints(this WebApplication application)
    {
        MapGetAllCities(application);
    }

    private static void MapGetAllCities(this WebApplication application)
    {
        application.MapGet("/cities", async (IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(new GetCitiesQuery(), token);

            return Results.Ok(result);
        })
        .WithName("GetAllCities")
        .WithOpenApi();
    }

    public static void MapCityPostEndpoints(this WebApplication application)
    {
        MapCreateCity(application);
    }

    private static void MapCreateCity(this WebApplication application)
    {
        application.MapPost("/city", async ([FromBody] CreateCityCommand command, IMediator mediator, CancellationToken token) =>
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
        .WithName("CreateCity")
        .WithOpenApi();
    }

}
