using Microsoft.AspNetCore.Mvc;
using TaskFlow.Aplication.DTOs.Tasks;
using TaskFlow.Aplication.Interfaces;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskDTO dto)
    {
        var task = await _taskService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new {id = task.Id}, task);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAllAsync();

        return Ok(tasks);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var task = await _taskService.GetByIdAsync(id);

        if (task is null) return NotFound();

        return Ok(task);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskDTO dto)
    {
        var task = await _taskService.UpdateAsync(id, dto);

        if (task is null) return NotFound();

        return Ok(task);
    }
}