namespace HealthCare.API.Endpoints;

[Route("api/user")]
[ApiController]
public class UserController(ILogger<UserController> logger, IUserService userService) : ControllerBase
{
    private readonly ILogger<UserController> Logger = logger;
    private readonly IUserService UserService = userService;


    #region GetUserDetails
    [HttpGet("user-list")]
    public IActionResult UserDetails()
    {
        return Ok(UserService.GetUserDetails());
    }
    #endregion
}
