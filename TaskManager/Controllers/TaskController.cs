using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : TaskManagerBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<Task>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok("Todas suas tarefas");
        }

    }
}
