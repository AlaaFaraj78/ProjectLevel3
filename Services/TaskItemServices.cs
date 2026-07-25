using Microsoft.EntityFrameworkCore;
using Pioneersacademy.Domains.Entities;
using Pioneersacademy.Domains.Interfaces;
using Pioneersacademy.Infrastacture;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pioneersacademy.Services;

public class TaskItemServices : ITaskItem
{
    private readonly TaskManagmentSystemDbContext _dbContext;
    private object generalResponse;

    public TaskItemServices(TaskManagmentSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Create(TaskItem taskItem)
    {
        taskItem.CreatedDate = DateTime.Now;
        taskItem.IsDeleted = false;

        await _dbContext.TaskItems.AddAsync(taskItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var taskid = await GetById(id);
        if (taskid is not null)
        {
            _dbContext.TaskItems.Remove(taskid);
            await _dbContext.SaveChangesAsync();
        }
    }

    public Task<List<TaskItem>> GetAll(int userId)
    {
        return _dbContext.TaskItems
            .AsNoTracking()
            .Where(t => t.AssignedUserId == userId && !t.IsDeleted)
            .ToListAsync();
    }

    public async Task<TaskItem> GetById(int id)
    {
        var taskItem = await _dbContext.TaskItems.FindAsync(id);
        return taskItem;
    }

    public Task Update(TaskItem taskItem)
    {
        throw new NotImplementedException();
    }
}
