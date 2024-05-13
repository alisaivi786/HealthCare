namespace HealthCare.Infrastructure.Services;
public class ServiceFilter
{
    protected IMapper mapper = GlobalContext.GetService<IMapper>();
    protected IClaimsAccessor CurrentUser = GlobalContext.GetService<IClaimsAccessor>(); 
}
