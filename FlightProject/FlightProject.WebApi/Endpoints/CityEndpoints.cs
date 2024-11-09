using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using FlightProject.WebApi.Extensions;
using FlightProject.WebApi.Models;
using FluentValidation;
using MediatR;

namespace FlightProject.WebApi.Endpoints;

public static class CityEndpoints
{
    public static void MapCityEndpoints(this WebApplication application)
    {
        MapCityGetEndpoints(application);
        MapCityPostEndpoints(application);
    }

    #region Get

    private static void MapCityGetEndpoints(this WebApplication application)
    {
        MapGetCityById(application);
        MapGetAllCities(application);
    }

    private static void MapGetCityById(this WebApplication application)
    {
        application.MapGet("/city/{id}", async (int id, CancellationToken token) =>
        {
            //var result = await dbContext.Cities.FindAsync([id], token);

            //if (result is null)
            //{
            //    return Results.NotFound();
            //}

            return Results.Ok(id);
        })
        .WithName("GetCityById")
        .WithOpenApi();
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

    #endregion

    #region Post

    public static void MapCityPostEndpoints(this WebApplication application)
    {
        MapCreateCity(application);
    }

    private static void MapCreateCity(this WebApplication application)
    {
        application.MapPost("/city", async (CreateCityCommand command, IMediator mediator, CancellationToken token) =>
        {
            try
            {
                await mediator.Send(command, token);
                //CreateCityDTOValidator validator = new();

                //await validator.ValidateAndThrowAsync(cityDto, token);

                //var city = new City
                //{
                //    Name = cityDto.Name
                //};

                //var result = await dbContext.Cities.AddAsync(city, token);

                //if (result is null)
                //{
                //    return Results.Problem();
                //}

                //await dbContext.SaveChangesAsync(token);

                //return Results.Created(string.Empty, new { result.Entity.Id });

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

    #endregion
}