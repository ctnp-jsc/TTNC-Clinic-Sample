using AutoMapper;
using Sample.Entities;

namespace Sample.Services;

public abstract class BaseService
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }
    protected ILogger Logger { get; }

    protected BaseService(IServiceProvider serviceProvider, ILogger logger)
    {
        UnitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        Mapper = serviceProvider.GetRequiredService<IMapper>();
        Logger = logger;
    }
}
