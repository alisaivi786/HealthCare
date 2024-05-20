namespace Common.JWT.Interface;

public interface IClaimsAccessorProvider
{
    IClaimsAccessor? Current { get; set; }
}
