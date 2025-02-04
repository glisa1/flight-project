using MediatR;

namespace FlightProject.Application.Models.Commands;

public sealed class LoginCommand(string username, string password) : IRequest<string>
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
}
