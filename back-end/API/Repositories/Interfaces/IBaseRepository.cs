using System.Linq.Expressions;
using API.Database;
using Core.Entities;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task<TEntity> DeleteAsync(TEntity entity);
}