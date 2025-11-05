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
    var entity = await _repo.GetByIdAsync(id);
    if (entity is null) return null;

    return new TaskReadDto
    {
      Id = entity.Id,
      Title = entity.Title,
      Description = entity.Description,
      CreationDate = entity.CreationDate,
      CompletionDate = entity.CompletionDate,
      Status = entity.Status,
      Responsible = entity.Responsible
    };
  }

  public async Task<List<TaskReadDto>> GetAllAsync(int pageNumber, int pageSize, TaskStatusEnum? status = null, string? responsible = null, DateOnly? completionDate = null)
  {
    var list = await _repo.GetAllAsync(pageNumber, pageSize, status, responsible, completionDate);
    return list.Select(entity => new TaskReadDto
    {
      Id = entity.Id,
      Title = entity.Title,
      Description = entity.Description,
      CreationDate = entity.CreationDate,
      CompletionDate = entity.CompletionDate,
      Status = entity.Status,
      Responsible = entity.Responsible
    }).ToList();
  }

  public async Task<bool> RemoveByIdAsync(int id)
  {
    return await _repo.RemoveByIdAsync(id);
  }

  public async Task<TaskReadDto?> UpdateAsync(int id, TaskUpdateDto dto)
  {
    var updated = await _repo.UpdateByIdAsync(id, existing =>
    {
      if (dto.Title is not null) existing.Title = dto.Title;
      if (dto.Description is not null) existing.Description = dto.Description;
      if (dto.CompletionDate.HasValue) existing.CompletionDate = dto.CompletionDate;
      if (dto.Status.HasValue) existing.Status = dto.Status.Value;
      if (dto.Responsible is not null) existing.Responsible = dto.Responsible;
    });

    if (updated is null) return null;

    return new TaskReadDto
    {
      Id = updated.Id,
      Title = updated.Title,
      Description = updated.Description,
      CreationDate = updated.CreationDate,
      CompletionDate = updated.CompletionDate,
      Status = updated.Status,
      Responsible = updated.Responsible
    };
  }
}
