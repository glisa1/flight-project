
using FlightProject.Domain.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Domain.Repository.Auth;

internal sealed class AuthRepository(AppDbContext dbContext) : IAuthRepository
{
    public async Task<IdentityUser?> GetUserByEmailAsync(string email, string password, CancellationToken cancellationToken)
    {
        return await dbContext
            .Users
            .AsNoTracking()
            .SingleOrDefaultAsync(user => user.Email == email, cancellationToken);
    }
}
