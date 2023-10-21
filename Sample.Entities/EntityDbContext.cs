using Microsoft.EntityFrameworkCore;

namespace Sample.Entities;

public class EntityDbContext : DbContext, IUnitOfWork
{
    public IUserService? UserService { get; internal set; }

    public EntityDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}
