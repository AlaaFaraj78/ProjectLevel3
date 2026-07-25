using Pioneersacademy.Domains.Entities;
using System.Reflection.Metadata;

namespace Pioneersacademy.Domains.Interfaces;

public interface IUser
{
    Task Create(User user);
    Task Update(User user);
    Task Delete(int id);
    Task<User> GetById(int id);
    Task<List<User>> GetAll();
}
