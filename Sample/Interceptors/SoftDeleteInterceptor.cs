using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Sample.Entities;
using Sample.Entities.Models;

namespace Sample.Interceptors;

public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is EntityDbContext context)
        {
            var userId = context.UserService?.CurrentUser;

            // Add Deleted User/Date
            context.ChangeTracker.Entries()
                .Where(x => x.Entity is ISoftDelete && x.State == EntityState.Deleted)
                .ToList()
                .ForEach(entry =>
                {
                    if (entry.Entity is ISoftDelete entity)
                    {
                        entity.DeletedAt = DateTimeOffset.UtcNow;
                        entity.DeletedBy = userId;
                        entry.State = EntityState.Modified;
                    }
                });
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
