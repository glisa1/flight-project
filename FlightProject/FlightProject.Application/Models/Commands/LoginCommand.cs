﻿using FlightProject.Shared;
using MediatR;

namespace FlightProject.Application.Models.Commands;

public sealed class LoginCommand(string email, string password) : IRequest<Result<string>>
{
    public string Email { get; } = email;
    public string Password { get; } = password;
}
