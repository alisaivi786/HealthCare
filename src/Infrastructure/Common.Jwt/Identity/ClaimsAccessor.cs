namespace Common.Jwt.Identity;

public class ClaimsAccessor(IPrincipalAccessor principalAccessor) : IdentityUser(principalAccessor), IClaimsAccessor
{
}
