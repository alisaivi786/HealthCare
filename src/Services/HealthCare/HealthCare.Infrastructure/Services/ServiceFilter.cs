namespace HealthCare.Infrastructure.Services;
public class ServiceFilter
{
    public IMapper mapper = GlobalContext.GetService<IMapper>(); 
}
