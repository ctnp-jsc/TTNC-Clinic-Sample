using Microsoft.AspNetCore.OData.Query;

namespace Sample.Repositories;

public interface IQueryRepository<T>
{
    Task<IQueryable> QueryAsync(ODataQueryOptions<T> QueryOptions, CancellationToken ct = default);
    Task<long?> CountAsync(ODataQueryOptions<T> QueryOptions, CancellationToken ct = default);
}
