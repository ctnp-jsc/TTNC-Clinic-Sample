using System.ComponentModel.DataAnnotations;

namespace Sample.Entities.Models;

public abstract class IdEntity : IEntity
{
    [Key]
    public string Id { get; set; } = default!;
}
