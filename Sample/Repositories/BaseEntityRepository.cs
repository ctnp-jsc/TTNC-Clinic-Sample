using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Sample.Entities;
using Sample.Entities.Models;
using System.Linq.Expressions;

namespace Sample.Repositories;

public abstract class BaseEntityRepository<TEntity> : BaseRepository<TEntity>, IQueryRepository<TEntity> where TEntity : class
{
    protected EntityDbContext Context { get; }

    protected virtual DbSet<TEntity> DataSet => Context.Set<TEntity>();

    protected virtual IQueryable<TEntity> GetQueryable(bool noTracking = false) =>
        noTracking ? DataSet.AsNoTracking() : DataSet;

    protected BaseEntityRepository(IServiceProvider serviceProvider, ILogger logger) : base(logger) =>
        Context = serviceProvider.GetRequiredService<EntityDbContext>();

    public virtual Task<IQueryable> QueryAsync(ODataQueryOptions<TEntity> QueryOptions, CancellationToken ct = default) =>
        Task.FromResult(QueryOptions.ApplyTo(GetQueryable(true)));

    public virtual Task<long?> CountAsync(ODataQueryOptions<TEntity> QueryOptions, CancellationToken ct = default) =>
        Task.FromResult(QueryOptions.Count?.GetEntityCount(GetQueryable(true)));
}

public abstract class BaseCrudEntityRepository<TEntity> : BaseEntityRepository<TEntity>, ICrudEntityRepository<TEntity> where TEntity : IdEntity
{
    protected BaseCrudEntityRepository(IServiceProvider serviceProvider, ILogger logger) : base(serviceProvider, logger)
    {
    }

    public virtual Task<TEntity?> FindByIdAsync(string id, bool noTracking = true, CancellationToken ct = default) =>
        GetQueryable(noTracking).FirstOrDefaultAsync(e => e.Id == id, ct);

    public virtual Task<TEntity?> FindByIdAsync(string id, CancellationToken ct = default) =>
        FindByIdAsync(id, false, ct);

    public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking, CancellationToken ct = default) =>
        GetQueryable(noTracking).FirstOrDefaultAsync(predicate, ct);

    public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default) =>
        FindAsync(predicate, false, ct);

    public Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking, CancellationToken ct = default) =>
        GetQueryable(noTracking).Where(predicate).ToListAsync(ct);

    public Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default) =>
        FindManyAsync(predicate, false, ct);

    public virtual Task<TEntity> AddAsync(TEntity model, CancellationToken ct = default)
    {
        Context.Entry(model).State = EntityState.Added;
        return Task.FromResult(model);
    }

    public virtual Task<TEntity> UpdateAsync(TEntity model, CancellationToken ct = default)
    {
        Context.Entry(model).State = EntityState.Modified;
        return Task.FromResult(model);
    }

    public virtual Task RemoveAsync(TEntity model, CancellationToken ct = default)
    {
        Context.Entry(model).State = EntityState.Deleted;
        return Task.CompletedTask;
    }
}
