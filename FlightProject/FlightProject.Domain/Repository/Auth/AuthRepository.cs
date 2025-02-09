
using FlightProject.Domain.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Domain.Repository.Auth;

internal sealed class AuthRepository(AppDbContext dbContext) : IAuthRepository
{
    public async Task<IdentityUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await dbContext
            .Users
            .AsNoTracking()
            .SingleOrDefaultAsync(user => user.Email == email, cancellationToken);
    }

    public async Task<string> CreateUserAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        await dbContext.Users.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
