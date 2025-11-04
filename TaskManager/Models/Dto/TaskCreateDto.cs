using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models.Dto;

public class TaskCreateDto
{
  [Required]
  public string Title { get; set; } = string.Empty;
  public string? Description { get; set; }
  public DateOnly? CompletionDate { get; set; }
  public TaskStatusEnum? Status { get; set; }
  public string? Responsible { get; set; }
}
