namespace Sample.Repositories;

public abstract class BaseRepository<TEntity>
{
    protected ILogger Logger { get; }

    protected BaseRepository(ILogger logger) => Logger = logger;
}
