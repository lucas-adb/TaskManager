using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public enum TaskStatusEnum
{
  Pendente,
  EmAndamento,
  Concluida
}

public class TaskEntity
{
  [Key]
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string? Description { get; set; }
  public DateOnly CreationDate { get; set; }
  public DateOnly? CompletionDate { get; set; }
  public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Pendente;
  public string? Responsible { get; set; }
}
