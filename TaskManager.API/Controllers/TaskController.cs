// Controllers/TaskController.cs
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.DTOS;
using TaskManager.Core.Interfaces.Services;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    // POST api/task (Crear tarea)
    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskDto taskCreateDTO)
    {
        try
        {
            var createdTask = await _taskService.CreateTaskAsync(taskCreateDTO);
            return Ok(createdTask);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/task (Obtener todas las tareas)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks([FromQuery]string? status)
    {
        try
        {
            var tasks = await _taskService.GetTasksAsync(status);
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/task/{id} (Actualizar tarea)
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskDto taskUpdateDTO)
    {
        try
        {
            await _taskService.UpdateTaskAsync(id, taskUpdateDTO);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/task/{id} (Eliminar tarea)
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(Guid id)
    {
        try
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
