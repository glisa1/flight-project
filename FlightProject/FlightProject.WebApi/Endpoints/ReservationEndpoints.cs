using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.WebApi.Endpoints;

public static class ReservationEndpoints
{
    public static void MapReservationEndpoints(this WebApplication application)
    {
        MapReservationGetEndpoints(application);
        MapReservationPostEndpoints(application);
    }

    private static void MapReservationGetEndpoints(this WebApplication application)
    {
        MapGetReservationById(application);
        MapGetAllReservationsForUser(application);
    }

    private static void MapGetReservationById(this WebApplication application)
    {
        application.MapGet("/reservation/{id}", async (int id, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(new GetReservationByIdQuery { Id = id }, token);

            return Results.Ok(result);
        })
        .WithName("GetReservationById")
        .WithOpenApi();
    }

    private static void MapGetAllReservationsForUser(this WebApplication application)
    {
        application.MapGet("/user-reservations/{userId}", async (int userId, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(new GetAllUserReservationsQuery
            {
                UserId = userId
            }, token);

            return Results.Ok(result);
        })
        .WithName("GetAllUserReservations")
        .WithOpenApi();
    }

    private static void MapReservationPostEndpoints(this WebApplication application)
    {
        MapCreateReservation(application);
    }

    private static void MapCreateReservation(this WebApplication application)
    {
        application.MapPost("/reservation", async ([FromBody] CreateReservationCommand command, IMediator mediator, CancellationToken token) =>
        {
            try
            {
                await mediator.Send(command, token);

                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithName("CreateReservation")
        .WithOpenApi();
    }

}
