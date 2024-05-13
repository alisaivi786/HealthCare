namespace Common.Jwt.Identity;

public class ClaimsAccessorProvider : IClaimsAccessorProvider
{
    public IClaimsAccessor? Current { get; set; }
    public AsyncLocal<IClaimsAccessor>? AccessorCurrent { get; set; }
}