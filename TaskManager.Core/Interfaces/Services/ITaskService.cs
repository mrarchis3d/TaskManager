using TaskManager.Core.DTOS;

namespace TaskManager.Core.Interfaces.Services;

public interface ITaskService
{
    Task<List<TaskDto>> GetTasksAsync(string? state);
    Task<TaskDto> CreateTaskAsync(CreateTaskDto taskDto);
    Task DeleteTaskAsync(Guid taskId);
    Task UpdateTaskAsync(Guid id, UpdateTaskDto taskDto);
}
