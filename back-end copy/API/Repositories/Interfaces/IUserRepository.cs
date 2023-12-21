using System.Linq.Expressions;
using Core.Entities;

namespace API.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<User> GetFirstAsync(Expression<Func<User, bool>> predicate);
    public Task<List<User>> GetAllAsync(Expression<Func<User, bool>> predicate);
    public Task<User> AddAsync(User entity);
    public Task<User> UpdateAsync(User entity);
    public Task<User> DeleteAsync(User entity);
}