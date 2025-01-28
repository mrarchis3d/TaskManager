using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Enums;
using TaskManager.Core.Exceptions;
using TaskManager.Core.Interfaces.Repositories;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{

    private readonly ApplicationContext _context;
    public TaskRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<Core.Entities.TaskEntity> CreateTaskAsync(Core.Entities.TaskEntity task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task DeleteTaskAsync(Guid taskId)
    {
        var task = await _context.Tasks.FindAsync(taskId);
        if (task != null) {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return;
        }
        throw new NotFoundException("Task not found");  
    }

    public async Task UpdateTaskAsync(Core.Entities.TaskEntity taskModel)
    {
        var task = await _context.Tasks.FindAsync(taskModel.Id);
        if (task != null)
        {
            _context.Entry(task).CurrentValues.SetValues(taskModel);
            await _context.SaveChangesAsync();
            return;
        }
        throw new NotFoundException("Task not found");
    }

    public async Task<IEnumerable<Core.Entities.TaskEntity>> GetTasksAsync(TaskState? state)
    {
        if (state.HasValue)
        {
            return await _context.Tasks.Where(x=> x.State == state.Value).ToListAsync();
        }
        return await _context.Tasks.ToListAsync();
    }
}
