namespace Common.JWT.Interface;

public interface IJwtTokenAuth
{
    string GenerateJwtToken(IAuthClaim authClaim);
}
