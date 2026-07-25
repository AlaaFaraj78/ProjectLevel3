using Pioneersacademy.Domains.Entities;

namespace Pioneersacademy.Domains.Interfaces;

public interface ITaskItem
{
    Task Create(TaskItem taskItem);
    Task Update(TaskItem taskItem);
    Task Delete(int id);
    Task<TaskItem> GetById(int id);
    Task<List<TaskItem>> GetAll(int userId);
}
