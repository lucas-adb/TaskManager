using System;

namespace TaskManager;

public class Task(int id, string title, string description, DateOnly creationDate, DateOnly completionDate, string status, string responsible)
{
  public int Id { get; set; } = id;
  public string Title { get; set; } = title;
  public string Description { get; set; } = description;
  public DateOnly CreationDate { get; set; } = creationDate;
  public DateOnly CompletionDate { get; set; } = completionDate;
  public string Status { get; set; } = status;
  public string Responsible { get; set; } = responsible;
}
