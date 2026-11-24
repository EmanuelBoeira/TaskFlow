using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence;

public class TaskFlowDBContext(
    DBContextOption<TaskFlowDBContext> options
    ) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.ToTable("tasks");

            entity.HasKey(task => task.Id);
            
            entity.Property(task => task.Title).HasMaxLength(2000).IsRequired();

            entity.Property(task => task.Description).HasMaxLength(2000).IsRequired();

            entity.Property(task => task.IsCompleted).IsRequired();

            entity.Property(task => task.CreatedAt).IsRequired();

            entity.Property(task => task.UpdatedAt);
        });
    }
}