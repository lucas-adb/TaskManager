using TaskManager.Models;
using TaskManager.Models.Dto;

namespace TaskManager.Services;

public interface ITaskService
{
  Task<TaskReadDto> CreateAsync(TaskCreateDto dto);
  Task<TaskReadDto?> GetByIdAsync(int id);
  Task<List<TaskReadDto>> GetAllAsync(TaskStatusEnum? status = null, string? responsible = null, DateOnly? completionDate = null);
  Task<bool> RemoveByIdAsync(int id);
}
