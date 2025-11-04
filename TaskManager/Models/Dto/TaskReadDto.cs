using System;

namespace TaskManager.Models.Dto;

public class TaskReadDto
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string? Description { get; set; }
  public DateOnly? CreationDate { get; set; }
  public DateOnly? CompletionDate { get; set; }
  public TaskStatusEnum Status { get; set; }
  public string? Responsible { get; set; }
}
