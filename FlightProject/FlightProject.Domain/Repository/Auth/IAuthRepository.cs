using Microsoft.AspNetCore.Identity;

namespace FlightProject.Domain.Repository.Auth;

public interface IAuthRepository
{
    Task<IdentityUser?> GetUserByEmailAsync(string email, string password, CancellationToken cancellationToken);
}
