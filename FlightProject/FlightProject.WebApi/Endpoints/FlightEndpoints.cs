using FlightProject.WebApi.Extensions;
using FlightProject.WebApi.Models;
using FluentValidation;

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
        application.MapGet("/flight/{id}", async (int id, CancellationToken token) =>
        {
            //var result = await dbContext.Flights.FindAsync([id], token);

            //if (result is null)
            //{
            //    return Results.NotFound();
            //}

            return Results.Ok(id);
        })
        .WithName("GetFlightById")
        .WithOpenApi();
    }

    private static void MapGetAllFlights(this WebApplication application)
    {
        application.MapGet("/flights", async (CancellationToken token) =>
        {
            //var result = await dbContext.Flights.ToListAsync(token);

            return Results.Ok();
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
        application.MapPost("/flight", async (CreateFlightDTO flightDto, CancellationToken token) =>
        {
            try
            {
                //CreateFlightDTOValidator validator = new();

                //await validator.ValidateAndThrowAsync(flightDto, token);

                //var source = await dbContext.Cities.SingleAsync(x => x.Id == flightDto.SourceId, token);
                //var destination = await dbContext.Cities.SingleAsync(x => x.Id == flightDto.DestinationId, token);
                //var plane = await dbContext.Planes.SingleAsync(x => x.Id == flightDto.PlaneId, token);

                //var flight = new Flight
                //{
                //    Source = source,
                //    Destination = destination,
                //    Plane = plane,
                //    Departure = flightDto.Departure,
                //    Price = flightDto.Price
                //};

                //var result = await dbContext.Flights.AddAsync(flight, token);

                //if (result is null)
                //{
                //    return Results.Problem();
                //}

                //await dbContext.SaveChangesAsync(token);

                //return Results.Created(string.Empty, new { result.Entity.Id });

                return Results.Ok(flightDto);

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
