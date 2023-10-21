using Microsoft.EntityFrameworkCore;
using Sample.Entities.Models;

namespace Sample.Entities;

public class EntityDbContext : DbContext, IUnitOfWork
{
    public IUserService? UserService { get; internal set; }
    public DbSet<AnswerEntity> Answers { get; set; } = default!;
    public DbSet<FormEntity> HRMForms { get; set; } = default!;
    public DbSet<QuestionEntity> Questions { get; set; } = default!;
    public DbSet<ResponseEntity> Responses { get; set; } = default!;
    public DbSet<ResponseDetailEntity> ResponseDetails { get; set; } = default!;
    public DbSet<UserEntity> Users { get; set; } = default!;

    public EntityDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}
