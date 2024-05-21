using AM.Code.Secrets;
using Common.JWT.Interface;
using Microsoft.AspNetCore.Mvc;
using IAuthClaim = Common.JWT.Interface.IAuthClaim;
using IJwtTokenAuth = Common.JWT.Interface.IJwtTokenAuth;

namespace TestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IJwtTokenAuth jwtTokenAuth, IAuthClaim authClaim) : ControllerBase
{
    [HttpGet("GetToken")]
    public IActionResult GetToken()
    {

        ARM aRM = new ARM();


        authClaim.UserId = "1";
        var response = jwtTokenAuth.GenerateJwtToken(authClaim);
        return Ok(response);
    }
}
