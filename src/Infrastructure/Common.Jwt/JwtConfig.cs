namespace Common.JWT;

public class JwtConfig : IJwtConfig
{
    public new string? SecretKey { get; set; }
    public new string? Issuer { get; set; }
    public new string? Audience { get; set; }
    public new string? TokenTime { get; set; }
}
