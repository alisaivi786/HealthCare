namespace Common.JWT.Identity;

public class ClaimsAccessor(IPrincipalAccessor principalAccessor) : IdentityUser(principalAccessor), IClaimsAccessor
{
}
