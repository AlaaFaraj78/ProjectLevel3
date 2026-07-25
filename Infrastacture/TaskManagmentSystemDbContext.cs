using Microsoft.EntityFrameworkCore;
using Pioneersacademy.Domains.Entities;
using TaskPriority = Pioneersacademy.Domains.Entities.TaskPriority;
using TaskStatus = Pioneersacademy.Domains.Entities.TaskStatus;

namespace Pioneersacademy.Infrastacture;

public class TaskManagmentSystemDbContext : DbContext
{
    public TaskManagmentSystemDbContext(DbContextOptions<TaskManagmentSystemDbContext> options)
        : base(options)
    {
        
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        TaskStatusSeedData(modelBuilder);
        TaskPrioritySeedData(modelBuilder);
    }
     


    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; } 
    public DbSet<TaskStatus> TaskStatuses { get; set; } 
    public DbSet<TaskPriority> TaskPriorities { get; set; }
    public DbSet<TaskComment> TaskComments { get; set; }





    private void TaskStatusSeedData(ModelBuilder modelBuilder)
    {  
        // Seed TaskStatuses
        modelBuilder.Entity<TaskStatus>().HasData(
            new TaskStatus { Id = 1, NameAr = "قيد الانتظار", NameEn = "Pending" },
            new TaskStatus { Id = 2, NameAr = "قيد التنفيذ", NameEn = "In Progress" },
            new TaskStatus { Id = 3, NameAr = "مكتمل", NameEn = "Completed" }
        ); 
    }

    private void TaskPrioritySeedData(ModelBuilder modelBuilder)
    {
        // Seed TaskPriorities
        modelBuilder.Entity<TaskPriority>().HasData(
            new TaskPriority { Id = 1, NameAr = "منخفض", NameEn = "Low" },
            new TaskPriority { Id = 2, NameAr = "متوسط", NameEn = "Medium" },
            new TaskPriority { Id = 3, NameAr = "مرتفع", NameEn = "High" }
        );
    }
}
