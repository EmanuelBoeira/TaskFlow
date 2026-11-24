using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence;

public class TaskFlowDBContext(
    DbContextOption<TaskFlowDBContext> options
    ) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.ToTable("tasks");

            entity.HasKey(task => task.Id).HasColumnName("Id");
            
            entity.Property(task => task.Title).HasColumnName("Title").HasMaxLength(2000).IsRequired();

            entity.Property(task => task.Description).HasColumnName("Description").HasMaxLength(2000).IsRequired();

            entity.Property(task => task.IsCompleted).HasColumnName("Iscompleted").IsRequired();

            entity.Property(task => task.CreatedAt).HasColumnName("CreatedAt").IsRequired();

            entity.Property(task => task.UpdatedAt).HasColumnName("UpdatedAt");
        });
    }
}