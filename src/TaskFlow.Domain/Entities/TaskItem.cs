namespace TaskFlow.Domain.Entities;

public class TaskItem
{
    public Guid Id {get; private set;}

    public string Title {get; private set;}

    public string Description {get; private set;}

    public bool IsCompleted {get; private set;}

    public DateTime CreatedAt {get; private set;}

    public DateTime? UpdatedAt {get; private set;}

    private TaskItem()
    {
        Title = string.Empty;
        Description = string.Empty;
    }

    public TaskItem(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        IsCompleted = false;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        IsCompleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}