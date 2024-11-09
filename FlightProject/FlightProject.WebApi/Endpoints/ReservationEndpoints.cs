using FlightProject.Application.Models.Queries;
using FlightProject.WebApi.Models;
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

    #region Get

    private static void MapReservationGetEndpoints(this WebApplication application)
    {
        MapGetReservationById(application);
        MapGetAllReservationsForUser(application);
    }

    private static void MapGetReservationById(this WebApplication application)
    {
        application.MapGet("/reservation/{id}", async (int id, CancellationToken token) =>
        {
            //var result = await dbContext.Reservations.FindAsync([id], token);

            //if (result is null)
            //{
            //    return Results.NotFound();
            //}

            return Results.Ok(id);
        })
        .WithName("GetReservationById")
        .WithOpenApi();
    }

    private static void MapGetAllReservationsForUser(this WebApplication application)
    {
        application.MapGet("/reservations", async ([FromBody]GetAllUserReservationsQuery getAllUserReservationsQuery, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(getAllUserReservationsQuery, token);

            return Results.Ok(result);
        })
        .WithName("GetAllReservations")
        .WithOpenApi();
    }

    #endregion

    #region Post

    private static void MapReservationPostEndpoints(this WebApplication application)
    {
        MapCreateReservation(application);
    }

    private static void MapCreateReservation(this WebApplication application)
    {
        application.MapPost("/reservation", async (CreateReservationDTO reservationDto, CancellationToken token) =>
        {
            try
            {
                //CreateReservationDTOValidator validator = new();

                //await validator.ValidateAndThrowAsync(reservationDto, token);

                //var flight = await dbContext.Flights.SingleAsync(flight => flight.Id == reservationDto.FlightId, token);

                //var reservation = new Reservation
                //{
                //    Flight = flight,
                //    UserId = reservationDto.UserId
                //};

                //var result = await dbContext.Reservations.AddAsync(reservation, token);

                //if (result is null)
                //{
                //    return Results.Problem();
                //}

                //await dbContext.SaveChangesAsync(token);

                //return Results.Created(string.Empty, new { result.Entity.Id });

                return Results.Ok(reservationDto);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithName("CreateReservation")
        .WithOpenApi();
    }

    #endregion

}
