
namespace FlightProject.UIClient.Services;

public class AuthService(string endpoint) : IAuthService
{
    private readonly string _apiEndpoint = endpoint;
    private readonly HttpClient _httpClient = new();

    public Task<bool> AuthenticateAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task Logut()
    {
        throw new NotImplementedException();
    }
}
