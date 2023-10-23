namespace Sample.Entities;

public interface IUserService
{
    Task<string?> GetCurrentUserAsync();
}
