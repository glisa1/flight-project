using FlightProject.Application.Models.Commands;
using FlightProject.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.WebApi.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication application)
    {
        MapLoginEndpoint(application);
        MapRegisterEndpoint(application);
    }

    private static void MapLoginEndpoint(this WebApplication application)
    {
        application.MapPost("/login", async ([FromBody] LoginCommand command, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(command, token);

            return result.Match(Results.Ok, Results.NotFound);
        })
        .WithName("Login")
        .WithTags(Tags.Auth)
        .WithOpenApi();
    }

    private static void MapRegisterEndpoint(this WebApplication application)
    {
        application.MapPost("/register", async ([FromBody] RegisterCommand command, IMediator mediator, CancellationToken token) =>
        {
            var result = await mediator.Send(command, token);

            return result.Match(Results.Ok, Results.NotFound);
        })
        .WithName("Register")
        .WithTags(Tags.Auth)
        .WithOpenApi();
    }
}
