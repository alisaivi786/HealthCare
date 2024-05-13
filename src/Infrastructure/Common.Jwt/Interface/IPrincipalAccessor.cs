using Microsoft.AspNetCore.Http;
namespace Common.Jwt.Interface;

public interface IPrincipalAccessor
{
    ClaimsPrincipal Principal { get; }
    HttpContext HttpContext { get; }
}
