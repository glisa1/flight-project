namespace FlightProject.UIClient.Models;

internal class AuthToken
{
    public string? TokenType { get; set; }
    public string? AccessToken { get; set; }
    public int ExpiresIn { get; set; }
    public string? RefreshToken { get; set; }

    public bool IsAuthenticated()
    {
        return AccessToken != null;
    }
}
