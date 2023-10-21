namespace Sample.Entities.Models;

public interface IAuditEntity : IEntity
{
    DateTimeOffset CreatedAt { get; set; }

    DateTimeOffset UpdatedAt { get; set; }

    string? CreatedBy { get; set; }

    string? UpdatedBy { get; set; }
}
