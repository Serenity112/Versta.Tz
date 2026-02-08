namespace Versta.Store.Infrastructure.Repository.Common;

public interface IRepositoryBase<T> where T : notnull
{
    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task<T?> GetByIdAsync(long id);

    Task SaveChangesAsync();
}
