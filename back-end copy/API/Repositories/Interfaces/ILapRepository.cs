using System.Linq.Expressions;
using Core.Entities;

namespace API.Repositories.Interfaces;

public interface ILapRepository
{
    public Task<Lap> GetFirstAsync(Expression<Func<Lap, bool>> predicate);
    public Task<List<Lap>> GetAllAsync(Expression<Func<Lap, bool>> predicate);
    public Task<Lap> AddAsync(Lap entity);
    public Task<Lap> UpdateAsync(Lap entity);
    public Task<Lap> DeleteAsync(Lap entity);
}