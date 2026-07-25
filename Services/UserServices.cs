using Microsoft.EntityFrameworkCore;
using Pioneersacademy.Domains.DTOs;
using Pioneersacademy.Domains.Entities;
using Pioneersacademy.Domains.Interfaces;
using Pioneersacademy.Infrastacture;

namespace Pioneersacademy.Services;

public class UserServices : IUser
{
    private readonly TaskManagmentSystemDbContext _dbContext;
    private object generalResponse;

    public UserServices(TaskManagmentSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    /// <summary>
    /// Creates a new user in the database.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task Create(User user)
    {
        // Check if the user already exists based on email address

        user.CreatedDate = DateTime.Now;
        user.IsDeleted = false;

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetById(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        return user;
    }

    public async Task Delete(int id)
    {
        var user = await GetById(id);
        if (user is not null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _dbContext.Users.Where(q => !q.IsDeleted)
            .AsNoTracking()
            .ToListAsync();

        return users;
    }

    public async Task Update(User user)
    {
        //var existingUser = await GetById(user.Id);
        //if (existingUser is not null)
        //{
        //    await _dbContext.Users.Update(user);
        //    await _dbContext.SaveChangesAsync();

        //}
        var existingUser = await GetById(user.Id);
        if (existingUser is not null)
        {
            _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
