namespace FlightProject.UIClient.Services;

public interface IAuthService
{
    Task<bool> AuthenticateAsync(string username, string password, CancellationToken cancellationToken = default);
    Task Logut(CancellationToken cancellationToken = default);
}
