namespace FlightProject.UIClient.Services;

public class AuthService(string serviceUrl) : IAuthService
{
    //private readonly string endpoint = endpoint;
    private readonly HttpClient _httpClient = new();

    public async Task<bool> AuthenticateAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        try
        {
            var endpoint = $"{serviceUrl}/login";
            var response = await _httpClient.PostAsJsonAsync(
                endpoint,
                new
                {
                    email = username,
                    password
                },
                cancellationToken);

            string responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
            Console.WriteLine(responseBody);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public Task Logut(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
