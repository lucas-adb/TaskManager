using System;
using TaskManager.Models;

namespace TaskManager.Data.Repositories;

public interface ITaskRepository
{
  Task<TaskEntity> AddAsync(TaskEntity entity);
  Task<TaskEntity?> GetByIdAsync(int id);
  Task<List<TaskEntity>> GetAllAsync();
  Task<bool> RemoveByIdAsync(int id);
}
