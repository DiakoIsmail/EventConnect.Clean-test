using EventConnect.Application.Contracts.Persistance;
using EventConnect.Domain.Common;
using EventConnect.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EventConnect.Persistence.Repositoryies;

public class GenericRepository<T>:IGenericRepository<T> where T : BaseEntity
{
    protected readonly EcDatabaseContext _context;

    public GenericRepository(EcDatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
// test
    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
       return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}