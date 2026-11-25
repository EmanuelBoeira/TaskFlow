using TaskFlow.Aplication.DTOs.Tasks;
using TaskFlow.Aplication.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Aplication.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskResponseDTO> CreateAsync(CreateTaskDTO dto)
    {
        var task = new TaskItem(
            dto.Title,
            dto.Description
        );

        await _taskRepository.AddAsync(task);

        return MapToResponse(task);
    }

    public async Task<IEnumerable<TaskResponseDTO>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();

        return tasks.Select(MapToResponse);
    }

    public async Task<TaskResponseDTO?> GetByIdAsync(Guid id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        return task is null ? null : MapToResponse(task);
    }

    public async Tas<TaskResponseDTO?> UpdateAsync(
        Guid id,
        UpdateTaslDTO dto
    )
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task is null) return nill;

        task.Update(dto.Title, dto.Description);

        await _taskRepository.UpdateAsync(task);

        return MapToResponse(task);
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