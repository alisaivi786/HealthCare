using HealthCare.Application.Contract.IServices;

namespace HealthCare.API.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class AccountController(ILogger<AccountController> logger, IAuthenticationService AuthService) : ControllerBase
{
    private readonly ILogger<AccountController> logger = logger;
    private readonly IAuthenticationService AuthService = AuthService;

    #region Register
    [HttpPost("Register")]
    public IActionResult Register()
    {
        return Ok("User Registered!");
    } 
    #endregion

    #region UpdateProfile
    [HttpPost("UpdateProfile")]
    public IActionResult UpdateProfile()
    {
        return Ok("Profile Updated!");
    } 
    #endregion

    #region Login
    [HttpPost("Login")]
    public IActionResult Login()
    {
        AuthService.AuthenticateUser();
        return Ok("User Loged in!");
    } 
    #endregion
}
