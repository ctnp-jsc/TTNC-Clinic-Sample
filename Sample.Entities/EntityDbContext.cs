using Microsoft.EntityFrameworkCore;
using Sample.Entities.Models;

namespace Sample.Entities;

public class EntityDbContext : DbContext
{
    public IUserService? UserService { get; internal set; }

    public DbSet<AnswerEntity> Answers { get; set; } = default!;
    public DbSet<FormEntity> Forms { get; set; } = default!;
    public DbSet<QuestionEntity> Questions { get; set; } = default!;
    public DbSet<ResponseEntity> Responses { get; set; } = default!;
    public DbSet<ResponseDetailEntity> ResponseDetails { get; set; } = default!;
    public DbSet<UserEntity> Users { get; set; } = default!;

    public EntityDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {


        builder.Entity<QuestionEntity>().
        HasMany(e => e.Answers).
        WithOne(e => e.Question).
        HasForeignKey(a => a.QuestionId).
        OnDelete(DeleteBehavior.NoAction);

        builder.Entity<FormEntity>()
        .HasMany(e => e.Questions)
        .WithOne(e => e.Form).
        HasForeignKey(a => a.FormId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ResponseEntity>()
        .HasMany(e => e.ResponseDetail)
        .WithOne(e => e.Response).
        HasForeignKey(a => a.ResponseId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
