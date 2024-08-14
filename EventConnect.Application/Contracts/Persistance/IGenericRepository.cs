using EventConnect.Domain.Common;

namespace EventConnect.Application.Contracts.Persistance;
// A generic repository interface that will be implemented by the GenericRepository class
public interface IGenericRepository<T> where T: BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
}

