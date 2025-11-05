using System;
using TaskManager.Models;

namespace TaskManager.Data.Repositories;

public interface ITaskRepository
{
  Task<TaskEntity> AddAsync(TaskEntity entity);
  Task<TaskEntity?> GetByIdAsync(int id);
  Task<List<TaskEntity>> GetAllAsync(int pageNumber, int pageSize, TaskStatusEnum? status = null, string? responsible = null, DateOnly? completionDate = null);
  Task<bool> RemoveByIdAsync(int id);
}
