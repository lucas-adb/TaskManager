using TaskManager.Models.Dto;

namespace TaskManager.Services;

public interface ITaskService
{
  Task<TaskReadDto> CreateAsync(TaskCreateDto dto);
  Task<TaskReadDto?> GetByIdAsync(int id);
  Task<List<TaskReadDto>> GetAllAsync();
}
