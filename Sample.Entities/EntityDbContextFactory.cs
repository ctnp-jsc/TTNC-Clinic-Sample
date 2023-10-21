using Microsoft.EntityFrameworkCore;
using Sample.Entities;

namespace Ulrich.Micro.PWPay.API.Entities;

public class EntityDbContextFactory : IDbContextFactory<EntityDbContext>
{
    private readonly IDbContextFactory<EntityDbContext> _pooledFactory;
    private readonly IUserService _userService;

    public EntityDbContextFactory(IDbContextFactory<EntityDbContext> pooledFactory, IUserService userService)
    {
        _pooledFactory = pooledFactory;
        _userService = userService;
    }

    public EntityDbContext CreateDbContext()
    {
        var context = _pooledFactory.CreateDbContext();
        context.UserService = _userService;
        return context;
    }
}
