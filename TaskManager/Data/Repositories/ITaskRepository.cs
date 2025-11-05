using System;
using TaskManager.Models;
using TaskManager.Models.Dto;

namespace TaskManager.Data.Repositories;

public interface ITaskRepository
{
  Task<TaskEntity> AddAsync(TaskEntity entity);
  Task<TaskEntity?> GetByIdAsync(int id);
  Task<List<TaskEntity>> GetAllAsync(int pageNumber, int pageSize, TaskStatusEnum? status = null, string? responsible = null, DateOnly? completionDate = null);
  Task<bool> RemoveByIdAsync(int id);

  Task<TaskEntity?> UpdateByIdAsync(int id, Action<TaskEntity> applyChanges);
}
