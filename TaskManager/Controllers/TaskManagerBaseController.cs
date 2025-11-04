using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class TaskManagerBaseController : ControllerBase
    {
        [HttpGet("health-check")]
        public IActionResult HealthCheck()
        {
            return Ok("It's Alive ⚡");
        }
    }
}
