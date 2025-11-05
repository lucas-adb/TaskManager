using System;

namespace TaskManager.Models.Dto;

public class TaskUpdateDto
{
  public string? Title { get; set; }
  public string? Description { get; set; }
  public DateOnly? CompletionDate { get; set; }
  public TaskStatusEnum? Status { get; set; }
  public string? Responsible { get; set; }
}
