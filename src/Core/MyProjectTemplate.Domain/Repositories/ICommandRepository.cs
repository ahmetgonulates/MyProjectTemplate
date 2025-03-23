namespace MyProjectTemplate.Domain.Repositories;

public interface ICommandRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<int> AddAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
}