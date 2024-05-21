

namespace HealthCare.Infrastructure.Services;

public class AuthenticationService(IJwtConfig jwtConfig,IAuthClaim authClaim, IJwtTokenAuth jwtTokenAuth) : IAuthenticationService
{
    public object AuthenticateUser()
    {
        authClaim.UserId = "1";
        var token = jwtTokenAuth.GenerateJwtToken(authClaim: authClaim);

        var response = new { token = token, Code = 100, MsgCode = "Login Successfully!" };
        return response;
    }

    public void AuthorizeAccess()
    {
        throw new NotImplementedException();
    }
}
