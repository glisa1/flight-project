namespace FlightProject.UIClient.Services;

public interface IAuthService
{
    Task<bool> AuthenticateAsync(string username, string password);
    Task Logut();
}
