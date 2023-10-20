using Sample.Entities.Models;
using System.Linq.Expressions;

namespace Sample.Repositories;

public interface ICrudEntityRepository<T> : ICrudRepository<T> where T : IdEntity
{
    Task<T?> FindByIdAsync(string id, bool noTracking, CancellationToken ct = default);
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate, bool noTracking, CancellationToken ct = default);
    Task<List<T>> FindManyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    Task<List<T>> FindManyAsync(Expression<Func<T, bool>> predicate, bool noTracking, CancellationToken ct = default);
}
