namespace TaskManager.Client.Services;

using global::TaskManager.Core.DTOS;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class TaskService
{
    private readonly HttpClient _httpClient;

    public List<TaskDto> Tasks
    {
        get;
        private set;
    } = new ();
    public void SetTasks(List<TaskDto> tasks)
    {
        Tasks = tasks;
    }

    public TaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TaskDto?> CreateTaskAsync(CreateTaskDto taskCreateDTO)
    {
        var response = await _httpClient.PostAsJsonAsync("api/task", taskCreateDTO);
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            var task = await response.Content.ReadFromJsonAsync<TaskDto>();
            await LoadTasksAsync();
            return task;
        }
        return null;
    }

    public async Task LoadTasksAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<TaskDto>>("api/task");
        if(response is not null)
            SetTasks(response.ToList());
    }

    public async Task<TaskDto> GetTaskByIdAsync(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<TaskDto>($"api/task/{id}");
        return response;
    }

    public async Task UpdateTaskAsync(Guid id, UpdateTaskDto taskDTO)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/task/{id}", taskDTO);
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            await LoadTasksAsync();
        }
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/task/{id}");
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            await LoadTasksAsync();
        }
    }
}
