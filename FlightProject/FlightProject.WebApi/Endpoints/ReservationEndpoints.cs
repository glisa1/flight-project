using FlightProject.Application.Models.Commands;
using FlightProject.Application.Models.Queries;
using FlightProject.WebApi.Extensions;
using FluentValidation;
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

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("GetReservationById")
        .WithTags(Tags.Reservation)
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

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("GetAllUserReservations")
        .WithTags(Tags.Reservation)
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
            var result = await mediator.Send(command, token);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("CreateReservation")
        .WithTags(Tags.Reservation)
        .WithOpenApi();
    }

}
