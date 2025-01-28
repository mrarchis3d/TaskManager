using TaskManager.Core.Entities;
using TaskManager.Core.Enums;

namespace TaskManager.Core.Interfaces.Repositories;

public interface ITaskRepository
{
    public Task<TaskEntity> CreateTaskAsync(TaskEntity task);
    public Task DeleteTaskAsync(Guid taskId);
    public Task UpdateTaskAsync(TaskEntity task);
    public Task<IEnumerable<TaskEntity>> GetTasksAsync(TaskState? state);
}
