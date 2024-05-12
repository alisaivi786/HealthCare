using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(ILogger<PatientController> logger) : ControllerBase
    {
        private readonly ILogger<PatientController> logger = logger;


        #region Book
        [HttpPost("Book")]
        public IActionResult Book()
        {
            return Ok("Patient Booked Appointment!");
        }
        #endregion

        #region Cancel
        [HttpPost("Cancel")]
        public IActionResult Cacnel()
        {
            return Ok("Patient Cancel Appointment!");
        }
        #endregion

        #region Register
        [HttpPost("Register")]
        public IActionResult Register()
        {
            return Ok("Patient Registered!");
        }
        #endregion

        #region UpdatePatient
        [HttpPost("UpdatePatient")]
        public IActionResult UpdatePatient()
        {
            return Ok("Update Patient!");
        }
        #endregion

        #region ViewAppointment
        [HttpPost("ViewAppointment")]
        public IActionResult ViewAppointment()
        {
            return Ok("View Appointment Patient!");
        }
        #endregion
    }
}
