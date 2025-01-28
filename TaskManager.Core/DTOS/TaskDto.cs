using TaskManager.Core.Enums;

namespace TaskManager.Core.DTOS;

public class TaskDto
{
    public Guid Id { get; set; }
    public string Tittle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public string State { get; set; } = string.Empty;
}
