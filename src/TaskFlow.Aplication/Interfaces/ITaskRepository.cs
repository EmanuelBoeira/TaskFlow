using TaskFlow.Domain.entities;

namespace ITaskRepository;

public interface ITaskRepository
{
    Task AssAsync(TaskItem task);

    Task<IEnumerable<TaskItem>> GetAllAsync();

    Task<TaskItem?> GetByIdAsync(Guid id);    
}