namespace Sample.Repositories;

public interface ICrudRepository<T>
{
    Task<T?> FindByIdAsync(string id, CancellationToken ct = default);
    Task<T> AddAsync(T model, CancellationToken ct = default);
    Task<T> UpdateAsync(T model, CancellationToken ct = default);
    Task RemoveAsync(T model, CancellationToken ct = default);
}
