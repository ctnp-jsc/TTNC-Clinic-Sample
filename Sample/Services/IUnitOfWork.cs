using Microsoft.EntityFrameworkCore;

namespace Sample.Entities;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}

public sealed class UnitOfWork<DB> : IUnitOfWork where DB : DbContext
{
    private readonly DB _dbContext;

    public UnitOfWork(IServiceProvider provider) =>
        _dbContext = provider.GetRequiredService<DB>();

    public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
        _dbContext.SaveChangesAsync(ct);
}
