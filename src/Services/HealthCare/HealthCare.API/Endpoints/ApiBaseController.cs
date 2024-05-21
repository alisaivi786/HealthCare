using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HealthCare.API.Endpoints;

[Authorize]
[ApiController]
public class ApiBaseController : ControllerBase
{
    protected IClaimsAccessor? CurrentUser => HttpContext.RequestServices.GetService<IClaimsAccessor>();
}
