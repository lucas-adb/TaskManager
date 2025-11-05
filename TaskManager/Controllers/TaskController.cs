using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Models.Dto;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : TaskManagerBaseController
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service) => _service = service;

        [HttpGet]
        [ProducesResponseType(typeof(List<TaskReadDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, int pageSize = 5, TaskStatusEnum? status = null, string? responsible = null, DateOnly? completionDate = null)
        {
            var tasks = await _service.GetAllAsync(pageNumber, pageSize, status, responsible, completionDate);
            return Ok(tasks);
        }

        [HttpGet("{id:int}", Name = "GetTaskById")]
        [ProducesResponseType(typeof(TaskReadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto is null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskReadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TaskCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _service.CreateAsync(createDto);
            return CreatedAtRoute("GetTaskById", new { id = created.Id }, created);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(TaskReadDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _service.RemoveByIdAsync(id);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}
