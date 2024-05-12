namespace HealthCare.API.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController(ILogger<AppointmentsController> logger) : ControllerBase
{
    private readonly ILogger<AppointmentsController> logger = logger;

    #region Book
    [HttpPost("Book")]
    public IActionResult Book()
    {
        return Ok("Patient Booked Appointment!");
    }
    #endregion

    #region Cancel
    [HttpPost("Cancel")]
    public IActionResult Cancel()
    {
        return Ok("Patient Cancel Appointment!");
    }
    #endregion

    #region Reschedule
    [HttpPost("Reschedule")]
    public IActionResult Reschedule()
    {
        return Ok("Patient Reschedule Appointment!");
    }
    #endregion
}
