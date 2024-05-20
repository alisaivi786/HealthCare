namespace Common.JWT.Identity;

public class PrincipalAccessor(IHttpContextAccessor httpContextAccessor) : IPrincipalAccessor
{
    public ClaimsPrincipal Principal => HttpContext?.User;

    public HttpContext HttpContext => _httpContextAccessor?.HttpContext;

    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
}