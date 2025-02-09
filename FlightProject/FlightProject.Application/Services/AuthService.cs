using FlightProject.Application.Models.Commands;
using FlightProject.Application.Util;
using FlightProject.Domain.Models.Identity;
using FlightProject.Domain.Repository.Auth;
using FlightProject.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FlightProject.Application.Services;

internal sealed class AuthService(IAuthRepository authRepository, ITokenProvider tokenProvider)
    :
    IRequestHandler<LoginCommand, Result<string>>,
    IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await authRepository.GetUserByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<string>(IdentityErrors.NotFoundByEmail);
        }

        var passwordHasher = new PasswordHasher<IdentityUser>();

        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, request.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            return Result.Failure<string>(IdentityErrors.NotFoundByEmail);
        }

        var token = tokenProvider.Create(user);

        return Result.Success(token);
    }

    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await authRepository.GetUserByEmailAsync(request.Email, cancellationToken);

        if (user is not null)
        {
            return Result.Failure<string>(IdentityErrors.EmailNotUnique);
        }

        var usernameUpper = request.Email.ToUpper();

        var newUser = new IdentityUser
        {
            Email = request.Email,
            UserName = request.Email,
            NormalizedEmail = usernameUpper,
            NormalizedUserName = usernameUpper
        };

        var passwordHasher = new PasswordHasher<IdentityUser>();
        newUser.PasswordHash = passwordHasher.HashPassword(newUser, request.Password);

        var userId = await authRepository.CreateUserAsync(newUser, cancellationToken);

        return Result.Success(userId);
    }
}
