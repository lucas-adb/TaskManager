using System;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data.Repositories;

public class TaskRepository : ITaskRepository
{
  private readonly AppDbContext _db;
  public TaskRepository(AppDbContext db) => _db = db;
  public async Task<TaskEntity> AddAsync(TaskEntity entity)
  {
    _db.Tasks.Add(entity);
    await _db.SaveChangesAsync();
    return entity;
  }

  public async Task<TaskEntity?> GetByIdAsync(int id)
  {
    return await _db.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
  }

  public async Task<List<TaskEntity>> GetAllAsync()
  {
    return await _db.Tasks.AsNoTracking().ToListAsync();
  }

  public async Task<bool> RemoveByIdAsync(int id)
  {
    var entity = await _db.Tasks.FindAsync(id);
    if (entity is null) return false;
    _db.Tasks.Remove(entity);
    await _db.SaveChangesAsync();
    return true;
  }
}
