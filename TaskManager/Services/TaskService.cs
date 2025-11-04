using System;
using TaskManager.Data.Repositories;
using TaskManager.Models;
using TaskManager.Models.Dto;

namespace TaskManager.Services;

public class TaskService : ITaskService
{
  private readonly ITaskRepository _repo;
  public TaskService(ITaskRepository repo) => _repo = repo;
  public async Task<TaskReadDto> CreateAsync(TaskCreateDto dto)
  {
    var entity = new TaskEntity
    {
      Title = dto.Title,
      Description = dto.Description,
      CreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
      CompletionDate = dto.CompletionDate,
      Status = dto.Status ?? TaskStatusEnum.Pendente,
      Responsible = dto.Responsible
    };

    var created = await _repo.AddAsync(entity);

    return new TaskReadDto
    {
      Id = created.Id,
      Title = created.Title,
      Description = created.Description,
      CreationDate = created.CreationDate,
      CompletionDate = created.CompletionDate,
      Status = created.Status,
      Responsible = created.Responsible
    };
  }

  public async Task<TaskReadDto?> GetByIdAsync(int id)
  {
    var e = await _repo.GetByIdAsync(id);
    if (e is null) return null;

    return new TaskReadDto
    {
      Id = e.Id,
      Title = e.Title,
      Description = e.Description,
      CreationDate = e.CreationDate,
      CompletionDate = e.CompletionDate,
      Status = e.Status,
      Responsible = e.Responsible
    };
  }

  public async Task<List<TaskReadDto>> GetAllAsync()
  {
    var list = await _repo.GetAllAsync();
    return list.Select(e => new TaskReadDto
    {
      Id = e.Id,
      Title = e.Title,
      Description = e.Description,
      CreationDate = e.CreationDate,
      CompletionDate = e.CompletionDate,
      Status = e.Status,
      Responsible = e.Responsible
    }).ToList();
  }

  public async Task<bool> RemoveByIdAsync(int id)
  {
    return await _repo.RemoveByIdAsync(id);
  }
}
