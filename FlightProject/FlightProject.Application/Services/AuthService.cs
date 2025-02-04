using FlightProject.Application.Models.Commands;
using FlightProject.Application.Util;
using FlightProject.Domain.Repository.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FlightProject.Application.Services;

internal sealed class AuthService(IAuthRepository authRepository, ITokenProvider tokenProvider) : IRequestHandler<LoginCommand, string>
{
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await authRepository.GetUserByEmailAsync(request.Username, request.Password, cancellationToken);

        if (user is null)
        {
            throw new Exception("User is null.");
        }

        var passwordHasher = new PasswordHasher<IdentityUser>();

        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, request.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            throw new Exception("Wrong password");
        }

        return tokenProvider.Create(user);
    }
}
