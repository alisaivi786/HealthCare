namespace Common.Jwt.Helpers;

public static class JwtHelpers
{
    public static TValue? GetClaim<TValue>(string key, IPrincipalAccessor? principal)
    {
        if (key.IsEmpty())
        {
            return default;
        }
        var claims = principal?.Principal?.Claims;
        if (claims != null && claims.IsEmpty())
        {
            return default;
        }
        var stringValue = claims?.FirstOrDefault(n => n.Type == key)?.Value;
        if (stringValue == null)
        {
            return default;
        }
        return (TValue)Convert.ChangeType(stringValue, typeof(TValue));
    }

    public static T? GetClaimToObj<T>(string key, IPrincipalAccessor? principal) where T : class
    {
        if (key.IsEmpty())
        {
            return default(T);
        }
        var claims = principal?.Principal?.Claims;
        if (claims != null && claims.IsEmpty())
        {
            return default(T);
        }
        var stringValue = claims?.FirstOrDefault(n => n.Type == key)?.Value;
        if (stringValue == null)
        {
            return default(T);
        }
        return JsonSerializer.Deserialize<T>(stringValue);
    }

    public static string? GetClaim(string key, IPrincipalAccessor? principal)
    {
        return GetClaim<string>(key, principal);
    }
}
