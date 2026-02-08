using Microsoft.EntityFrameworkCore;
using Versta.Store.Models.Domain.Common;

namespace Versta.Store.Infrastructure.Repository.Common;

public abstract class RepositoryBase<T>(AppDbContext dbContext) : IRepositoryBase<T> where T : BaseEntity
{
    public void Add(T entity)
    {
        dbContext.Add(entity);
    }

    public void Update(T entity)
    {
        dbContext.Update(entity);
    }

    public void Delete(T entity)
    {
        dbContext.Remove(entity);
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        var result = await dbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == id);

        return result;
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
