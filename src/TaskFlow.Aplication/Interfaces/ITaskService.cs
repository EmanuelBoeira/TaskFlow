using TaskFlow.Aplication.DTOs.Tasks;

namespace TaskFlow.Aplication.Interfaces;

public interface ITaskService
{
    Task<TaskResponseDTO> CreateAsync(CreateTaskDTO dto);

    Task<IEnumerable<TaskResponseDTO>> GetAllAsync();

    Task<TaskResponseDTO?> GetByIdAsync(Guid id);

    Task<TaskResponseDTO?> UpdateAsync(Guid id, UpdateTaskDTO dto);

    Task<bool> DeleteAsync(Guid id);
}