namespace Common.JWT.Identity;

public class IdentityUser(IPrincipalAccessor principalAccessor) : IIdentityUser
{
    protected IPrincipalAccessor PrincipalAccessor { get; set; } = principalAccessor;

    public string? UserId => JwtHelpers.GetClaim(AuthClaimTypes.UserId, principal: PrincipalAccessor);
    public string? UserName => JwtHelpers.GetClaim(AuthClaimTypes.UserName, principal: PrincipalAccessor);
    public string? NickName => JwtHelpers.GetClaim(AuthClaimTypes.NickName, principal: PrincipalAccessor);
    public string? UserPhoto => JwtHelpers.GetClaim(AuthClaimTypes.UserPhoto, principal: PrincipalAccessor);
    public DateTime? LoginTime => Convert.ToDateTime(JwtHelpers.GetClaim(AuthClaimTypes.LoginTime, principal: PrincipalAccessor));
    public string? LoginIPAddress => JwtHelpers.GetClaim(AuthClaimTypes.LoginIPAddress, principal: PrincipalAccessor);
    public TokenTypeEnum? TokenType => (TokenTypeEnum)JwtHelpers.GetClaim(AuthClaimTypes.TokenType, principal: PrincipalAccessor).GetIntValueByEnum<TokenTypeEnum>();
    public string? Isvalidator => JwtHelpers.GetClaim(AuthClaimTypes.Isvalidator, principal: PrincipalAccessor);
    public string? PhoneType => JwtHelpers.GetClaim(AuthClaimTypes.PhoneType, principal: PrincipalAccessor);
    public string? UserType => JwtHelpers.GetClaim(AuthClaimTypes.UserType, principal: PrincipalAccessor);

    public string? IdentityUserName => JwtHelpers.GetClaim(AuthClaimTypes.IdentityUserName, principal: PrincipalAccessor);
    public string? Name => JwtHelpers.GetClaim(AuthClaimTypes.Name, principal: PrincipalAccessor);
    public string? GivenName => JwtHelpers.GetClaim(AuthClaimTypes.GivenName, principal: PrincipalAccessor);
    public string? FamilyName => JwtHelpers.GetClaim(AuthClaimTypes.FamilyName, principal: PrincipalAccessor);
    public string? MiddleName => JwtHelpers.GetClaim(AuthClaimTypes.MiddleName, principal: PrincipalAccessor);
    public string? Nickname => JwtHelpers.GetClaim(AuthClaimTypes.Nickname, principal: PrincipalAccessor);
    public string? PreferredUsername => JwtHelpers.GetClaim(AuthClaimTypes.PreferredUsername, principal: PrincipalAccessor);
    public string? Profile => JwtHelpers.GetClaim(AuthClaimTypes.Profile, principal: PrincipalAccessor);
    public string? Picture => JwtHelpers.GetClaim(AuthClaimTypes.Picture, principal: PrincipalAccessor);
    public string? Website => JwtHelpers.GetClaim(AuthClaimTypes.Website, principal: PrincipalAccessor);
    public string? Email => JwtHelpers.GetClaim(AuthClaimTypes.Email, principal: PrincipalAccessor);
    public string? EmailVerified => JwtHelpers.GetClaim(AuthClaimTypes.EmailVerified, principal: PrincipalAccessor);
    public string? Gender => JwtHelpers.GetClaim(AuthClaimTypes.Gender, principal: PrincipalAccessor);
    public string? Birthdate => JwtHelpers.GetClaim(AuthClaimTypes.Birthdate, principal: PrincipalAccessor);
    public string? Zoneinfo => JwtHelpers.GetClaim(AuthClaimTypes.Zoneinfo, principal: PrincipalAccessor);
    public string? Locale => JwtHelpers.GetClaim(AuthClaimTypes.Locale, principal: PrincipalAccessor);
    public string? PhoneNumber => JwtHelpers.GetClaim(AuthClaimTypes.PhoneNumber, principal: PrincipalAccessor);
    public string? PhoneNumberVerified => JwtHelpers.GetClaim(AuthClaimTypes.PhoneNumberVerified, principal: PrincipalAccessor);
    public string? Address => JwtHelpers.GetClaim(AuthClaimTypes.Address, principal: PrincipalAccessor);
    public string? UpdatedAt => JwtHelpers.GetClaim(AuthClaimTypes.UpdatedAt, principal: PrincipalAccessor);
    public string? Role => JwtHelpers.GetClaim(AuthClaimTypes.Role, principal: PrincipalAccessor);
    public string? Groups => JwtHelpers.GetClaim(AuthClaimTypes.Groups, principal: PrincipalAccessor);
    public string? Permissions => JwtHelpers.GetClaim(AuthClaimTypes.Permissions, principal: PrincipalAccessor);
    public string? Custom1 => JwtHelpers.GetClaim(AuthClaimTypes.Custom1, principal: PrincipalAccessor);
    public string? Custom2 => JwtHelpers.GetClaim(AuthClaimTypes.Custom2, principal: PrincipalAccessor);
    public string? Custom3 => JwtHelpers.GetClaim(AuthClaimTypes.Custom3, principal: PrincipalAccessor);
    public string? Custom4 => JwtHelpers.GetClaim(AuthClaimTypes.Custom4, principal: PrincipalAccessor);
    public string? Custom5 => JwtHelpers.GetClaim(AuthClaimTypes.Custom5, principal: PrincipalAccessor);
    public string? Custom6 => JwtHelpers.GetClaim(AuthClaimTypes.Custom6, principal: PrincipalAccessor);
    public string? Custom7 => JwtHelpers.GetClaim(AuthClaimTypes.Custom7, principal: PrincipalAccessor);
    public string? Custom8 => JwtHelpers.GetClaim(AuthClaimTypes.Custom8, principal: PrincipalAccessor);

   


    //protected TValue? GetClaim<TValue>(string key)
    //{
    //    if (key.IsEmpty())
    //    {
    //        return default;
    //    }
    //    var claims = PrincipalAccessor.Principal?.Claims;
    //    if (claims!= null && claims.IsEmpty())
    //    {
    //        return default;
    //    }
    //    var stringValue = claims?.FirstOrDefault(n => n.Type == key)?.Value;
    //    if (stringValue == null)
    //    {
    //        return default;
    //    }
    //    return (TValue)Convert.ChangeType(stringValue, typeof(TValue));
    //}

    //protected T? GetClaimToObj<T>(string key) where T : class
    //{
    //    if (key.IsEmpty())
    //    {
    //        return default(T);
    //    }
    //    var claims = PrincipalAccessor.Principal?.Claims;
    //    if (claims != null && claims.IsEmpty())
    //    {
    //        return default(T);
    //    }
    //    var stringValue = claims?.FirstOrDefault(n => n.Type == key)?.Value;
    //    if (stringValue == null)
    //    {
    //        return default(T);
    //    }
    //    return System.Text.Json.JsonSerializer.Deserialize<T>(stringValue);
    //}

    //protected string? GetClaim(string key)
    //{
    //    return GetClaim<string>(key);
    //}
}