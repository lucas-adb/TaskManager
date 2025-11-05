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

  public async Task<List<TaskEntity>> GetAllAsync(int pageNumber, int pageSize, TaskStatusEnum? status = null, string? responsible = null, DateOnly? completionDate = null)
  {
    IQueryable<TaskEntity> query = _db.Tasks.AsNoTracking();
    if (status.HasValue) query = query.Where(t => t.Status == status.Value);
    if (!string.IsNullOrWhiteSpace(responsible)) query = query.Where(t => t.Responsible == responsible);
    if (completionDate.HasValue) query = query.Where(t => t.CompletionDate == completionDate.Value);
    return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
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
