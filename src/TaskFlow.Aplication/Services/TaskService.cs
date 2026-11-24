using TaskFlow.Aplication.DTOs.Tasks;
using TaskFlow.Aplication.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Aplication.Services;

public class TaskService : ITaskService
{
    private readonly List<TaskItem> _tasks = new();

    public Task<TaskResponseDTO> CreateAsync(CreateTaskDTO dto)
    {
        var task = new TaskItem(
            dto.Title,
            dto.Description
        );

        _tasks.Add(task);

        var response = MapToResponse(task);

        return Task.FromResult(response);
    }

    public Task<IEnumerable<TaskResponseDTO>> GetAllAsync()
    {
        var response = _tasks.Select(MapToResponse);

        return Task.FromResult(
            (IEnumerable<TaskResponseDTO>)response
        );
    }

    public Task<TaskResponseDTO?> GetByIdAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        var response = task is null ? null : MapToResponse(task);

        return Task.FromResult(response);
    }

    private static TaskResponseDTO MapToResponse(TaskItem task)
    {
        return new TaskResponseDTO
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt
        };
    }
}