using MyProjectTemplate.Domain.Results;

namespace MyProjectTemplate.Domain.Repositories;

public interface IQueryRepository<TEntity> 
    where TEntity : BaseEntity
{
    Task<ResultT<IEnumerable<TEntity>>> GetAllAsync();
    Task<ResultT<TEntity?>> GetByIdAsync(Guid id);
}