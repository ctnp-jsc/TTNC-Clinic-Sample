namespace Sample.Entities.Models;

public interface ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
