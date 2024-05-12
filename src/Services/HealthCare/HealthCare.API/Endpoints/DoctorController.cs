using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(ILogger<DoctorController> logger, IDoctorService doctorService) : ControllerBase
    {
        private readonly ILogger<DoctorController> logger = logger;
        private readonly IDoctorService DoctorService = doctorService;

        #region Register
        [HttpPost("Register")]
        public IActionResult Register()
        {
            return Ok("Doctor Registered!");
        }
        #endregion

        #region AddSchedule
        [HttpPost("AddSchedule")]
        public IActionResult AddSchedule()
        {
            return Ok("Add Doctor Schedule!");
        }
        #endregion

        #region Cancel
        [HttpPost("Cancel")]
        public IActionResult Cacnel()
        {
            return Ok("Doctor Cancel Appointment!");
        }
        #endregion

        #region UpdateSchedule
        [HttpPost("UpdateSchedule")]
        public IActionResult UpdateSchedule()
        {
            return Ok("Doctor Update Schedule!");
        }
        #endregion
        
        #region UpdateSchedule
        [HttpGet("doctor-list")]
        public IActionResult GetDoctorList()
        {

            return Ok(DoctorService.GetDoctorDetails());
        }
        #endregion
    }
}
