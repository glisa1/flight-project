using Microsoft.AspNetCore.Identity;

namespace FlightProject.Domain.Repository.Auth;

public interface IAuthRepository
{
    Task<IdentityUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    Task<string> CreateUserAsync(IdentityUser user, CancellationToken cancellationToken);
}
