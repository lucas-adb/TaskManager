using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : TaskManagerBaseController
    {
        private readonly AppDbContext _db;
        public TaskController(AppDbContext db) => _db = db;

        [HttpGet]
        [ProducesResponseType(typeof(List<TaskEntity>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _db.Tasks.AsNoTracking().ToListAsync();
            return Ok(tasks);
        }

    }
}
