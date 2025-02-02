using FlightProject.UIClient.Models;

namespace FlightProject.UIClient.Services;

internal class AuthService(string serviceUrl) : IAuthService
{
    //private readonly string endpoint = endpoint;
    private readonly string _endpoint = $"{serviceUrl}/login";
    private readonly HttpClient _httpClient = new();

    public async Task<AuthToken?> AuthenticateAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(
                _endpoint,
                new
                {
                    email = username,
                    password
                },
                cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AuthToken>(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Task Logut(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
