using FlightProject.Application.Models.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.WebApi.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication application)
    {
        MapLoginEndpoint(application);
    }

    private static void MapLoginEndpoint(this WebApplication application)
    {
        application.MapPost("/login", async ([FromBody] LoginCommand command, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(command, token);

            return Results.Ok(result);
        })
        .WithName("Login")
        .WithTags(Tags.Auth)
        .WithOpenApi();
    }
}
