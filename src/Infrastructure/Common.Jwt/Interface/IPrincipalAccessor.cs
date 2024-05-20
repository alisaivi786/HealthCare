namespace Common.JWT.Interface;

public interface IPrincipalAccessor
{
    ClaimsPrincipal Principal { get; }
    HttpContext HttpContext { get; }
}
