using System.Linq.Expressions;
using Core.Entities;

namespace API.Repositories.Interfaces;

public interface IEventRepository
{
    public Task<Event> GetFirstAsync(Expression<Func<Event, bool>> predicate);
    public Task<List<Event>> GetAllAsync(Expression<Func<Event, bool>> predicate);
    public Task<Event> AddAsync(Event entity);
    public Task<Event> UpdateAsync(Event entity);
    public Task<Event> DeleteAsync(Event entity);
}