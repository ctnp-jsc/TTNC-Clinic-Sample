using Microsoft.AspNetCore.OData.Query;
using Sample.Entities.Models;
using Sample.Repositories;

namespace Sample.Services;

public abstract class BaseEntityService<TEntity, TRepository> : BaseService<TEntity> where TRepository : notnull
{
    protected readonly TRepository Repository;

    protected BaseEntityService(IServiceProvider serviceProvider, ILogger logger) : base(serviceProvider, logger) =>
        Repository = serviceProvider.GetRequiredService<TRepository>();

    public virtual Task<IQueryable> QueryAsync(ODataQueryOptions<TEntity> queryOptions, CancellationToken ct = default)
    {
        if (Repository is IQueryRepository<TEntity> queryRepository)
        {
            return queryRepository.QueryAsync(queryOptions, ct);
        }
        throw new Exception($"Doesn't have implement for {nameof(IQueryRepository<TEntity>)}");
    }

    public virtual Task<long?> CountAsync(ODataQueryOptions<TEntity> queryOptions, CancellationToken ct = default)
    {
        if (Repository is IQueryRepository<TEntity> queryRepository)
        {
            return queryRepository.CountAsync(queryOptions, ct);
        }
        throw new Exception($"Doesn't have implement for {nameof(IQueryRepository<TEntity>)}");
    }
}

public abstract class BaseCrudEntityService<TEntity, TRepository, TQueryRepository> : BaseEntityService<TEntity, TRepository>
    where TEntity : IdEntity
    where TRepository : ICrudEntityRepository<TEntity>
    where TQueryRepository : IQueryRepository<TEntity>
{
    protected BaseCrudEntityService(IServiceProvider serviceProvider, ILogger logger) : base(serviceProvider, logger)
    {
    }

    public virtual Task<TEntity?> FindByIdAsync(string id, CancellationToken ct = default) =>
        Repository.FindByIdAsync(id, ct);

    public virtual async Task<TEntity> CreateAsync(TEntity model, CancellationToken ct = default)
    {
        model = await Repository.AddAsync(model, ct);
        await UnitOfWork.SaveChangesAsync(ct);
        return model;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity model, CancellationToken ct = default)
    {
        await Repository.UpdateAsync(model, ct);
        await UnitOfWork.SaveChangesAsync(ct);
        return model;
    }

    public virtual async Task<TEntity> CreateOrUpdateAsync(TEntity model, CancellationToken ct = default)
    {
        var entity = await FindByIdAsync(model.Id, ct);
        return entity is null ? await CreateAsync(model, ct) : await UpdateAsync(entity, ct);
    }

    public virtual async Task<TEntity> CreateIfNotExistAsync(TEntity model, CancellationToken ct = default)
    {
        var entity = await FindByIdAsync(model.Id, ct);
        return entity ?? await CreateAsync(model, ct);
    }

    public virtual async Task DeleteAsync(TEntity model, CancellationToken ct = default)
    {
        await Repository.RemoveAsync(model, ct);
        await UnitOfWork.SaveChangesAsync(ct);
    }
}

public abstract class BaseCrudEntityService<TEntity, TRepository> : BaseCrudEntityService<TEntity, TRepository, TRepository>
    where TEntity : IdEntity
    where TRepository : ICrudEntityRepository<TEntity>, IQueryRepository<TEntity>
{
    protected BaseCrudEntityService(IServiceProvider serviceProvider, ILogger logger) : base(serviceProvider, logger)
    {
    }
}

