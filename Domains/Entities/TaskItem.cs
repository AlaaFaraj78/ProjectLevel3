using System.ComponentModel.DataAnnotations;

namespace Pioneersacademy.Domains.Entities;

public class TaskItem : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    public Pioneersacademy.Domains.Enums.TaskStatus Status { get; set; }
    
    public Pioneersacademy.Domains.Enums.TaskPriority Priority { get; set; }
    
    public DateTime DueDate { get; set; }

    public int AssignedUserId { get; set; }

    public User AssignedUser { get; set; }


    public ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();
}
