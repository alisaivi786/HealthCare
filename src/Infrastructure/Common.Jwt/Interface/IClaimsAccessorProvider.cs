namespace Common.Jwt.Interface;

public interface IClaimsAccessorProvider
{
    IClaimsAccessor? Current { get; set; }
}
