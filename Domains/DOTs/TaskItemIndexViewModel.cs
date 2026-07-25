using Pioneersacademy.Domains.Entities;
using System.Collections.Generic;

namespace Pioneersacademy.Domains.DTOs;

public class TaskItemIndexViewModel
{
    public User UserInfo { get; set; }
    public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public List<Entities.TaskStatus> Statuses { get; set; } = new List<Entities.TaskStatus>();
    public List<TaskPriority> Priorities { get; set; } = new List<TaskPriority>();
}
