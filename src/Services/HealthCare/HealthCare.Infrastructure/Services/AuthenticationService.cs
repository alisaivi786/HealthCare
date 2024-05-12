using Common.Jwt;

namespace HealthCare.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    AuthClaim authClaim = new();
    public void AuthenticateUser()
    {
        authClaim.CurrentUserId = "1";
        var token = JwtTokenAuth.GenerateJwtToken(authClaim: authClaim);
    }

    public void AuthorizeAccess()
    {
        throw new NotImplementedException();
    }
}
