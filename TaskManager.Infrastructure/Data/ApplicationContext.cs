using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;

namespace TaskManager.Infrastructure.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<TaskEntity> Tasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de TaskEntity
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Tittle)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.Description)
                  .IsRequired()
                  .HasMaxLength(1000);

            entity.Property(e => e.DueDate)
                  .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.State)
                  .HasDefaultValue(TaskState.PENDING);
        });

    }
}
