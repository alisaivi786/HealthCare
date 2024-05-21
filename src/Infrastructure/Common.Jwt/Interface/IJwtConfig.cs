namespace Common.JWT.Interface;

public interface IJwtConfig
{
    public string? SecretKey { get; }
    public string? Issuer { get; }
    public string? Audience { get; }
    public string? TokenTime { get; }
}
