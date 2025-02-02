using FlightProject.UIClient.Models;

namespace FlightProject.UIClient.Services;

internal interface IAuthService
{
    Task<AuthToken?> AuthenticateAsync(string username, string password, CancellationToken cancellationToken = default);
    Task Logut(CancellationToken cancellationToken = default);
}
