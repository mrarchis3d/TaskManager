namespace TaskManager.Core.DTOS;

public class CreateTaskDto
{
    public string Tittle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } = DateTime.Now;
}
