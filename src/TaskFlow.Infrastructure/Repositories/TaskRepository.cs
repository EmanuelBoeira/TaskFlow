using Microsoft.EntityFrameworkCore;
using TaskFlow.Aplication.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Persistence;

namespace TaskFlow.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskFlowDBContext _context;

    public TaskRepository(TaskFlowDBContext context)
    {
        _context = context;
    }

    public async Task AddAsync(taskItem task)
    {
        await _context.Tasks.AddAsync(task);

        await  _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks.AsNoTracking().ToListAsync();
    }

    public async Task<TaskItem> GetByIdAsync(Guid id)
    {
        return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(task => task.Id == id);
    }
}