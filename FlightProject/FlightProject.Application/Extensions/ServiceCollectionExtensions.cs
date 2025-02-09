﻿using FlightProject.Application.Util;
using FlightProject.WebApi.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FlightProject.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        services.AddSingleton<ITokenProvider, TokenProvider>();
    }
}
