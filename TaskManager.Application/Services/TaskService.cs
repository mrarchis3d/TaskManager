// Application/Services/TaskService.cs
using AutoMapper;
using TaskManager.Core.DTOS;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;
using TaskManager.Core.Interfaces.Repositories;
using TaskManager.Core.Interfaces.Services;

namespace TaskManager.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<List<TaskDto>> GetTasksAsync(string? state)
    {
        TaskState? taskState = null;

        if (!string.IsNullOrEmpty(state) && Enum.TryParse<TaskState>(state, true, out var parsedState))
        {
            taskState = parsedState;
        }

        var tasks = await _taskRepository.GetTasksAsync(taskState);
        return _mapper.Map<List<TaskDto>>(tasks);
    }

    public async Task<TaskDto> CreateTaskAsync(CreateTaskDto taskDto)
    {
        var taskEntity = _mapper.Map<TaskEntity>(taskDto);
        taskEntity.State = TaskState.PENDING;
        var createdTask = await _taskRepository.CreateTaskAsync(taskEntity);
        return _mapper.Map<TaskDto>(createdTask);
    }

    public async Task DeleteTaskAsync(Guid taskId)
    {
        await _taskRepository.DeleteTaskAsync(taskId);
    }

    public async Task UpdateTaskAsync(Guid id, UpdateTaskDto taskDto)
    {
        var taskEntity = _mapper.Map<TaskEntity>(taskDto);
        taskEntity.Id = id;
        await _taskRepository.UpdateTaskAsync(taskEntity);
    }
}
