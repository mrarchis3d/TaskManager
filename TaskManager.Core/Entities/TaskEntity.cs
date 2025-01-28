using TaskManager.Core.Enums;

namespace TaskManager.Core.Entities;

public class TaskEntity : BaseEntity
{
    public required string Tittle { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskState State { get; set; }
}