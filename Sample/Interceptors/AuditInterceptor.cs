using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Sample.Entities;
using Sample.Entities.Models;

namespace Sample.Interceptors;

public sealed class AuditInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken ct = default)
    {
        if (eventData.Context is EntityDbContext context)
        {
            var userId = context.UserService is null ? null : await context.UserService.GetCurrentUserAsync();

            // Add Created/Updated User/Date
            context.ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditEntity && (x.State == EntityState.Added || x.State == EntityState.Modified))
                .ToList()
                .ForEach(entry =>
                {
                    if (entry.Entity is IAuditEntity auditEntity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            auditEntity.CreatedAt = DateTimeOffset.UtcNow;
                            auditEntity.CreatedBy = userId;
                        }

                        auditEntity.UpdatedAt = DateTimeOffset.UtcNow;
                        auditEntity.UpdatedBy = userId;
                    }
                });
        }
        return await base.SavingChangesAsync(eventData, result, ct);
    }
}
