using Microsoft.AspNetCore.Identity;

namespace FlightProject.Application.Util;

public interface ITokenProvider
{
    string Create(IdentityUser user);
}
