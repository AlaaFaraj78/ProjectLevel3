using System.ComponentModel.DataAnnotations;

namespace Pioneersacademy.Domains.Entities;

public class User : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }


    [Required]
    [MaxLength(100)]
    public string EmailAddress { get; set; }


    public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

  
}
