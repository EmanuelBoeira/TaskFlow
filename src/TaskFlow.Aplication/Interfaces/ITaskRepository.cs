using TaskFlow.Domain.Entities;

namespace TaskFlow.Aplication.Interfaces;

public interface ITaskRepository
{
    Task AddAsync(TaskItem task);

    Task<IEnumerable<TaskItem>> GetAllAsync();

    Task<TaskItem?> GetByIdAsync(Guid id);

    Task UpdateAsync(TaskItem task);

    Task DeleteAsync(TaskItem task);
}