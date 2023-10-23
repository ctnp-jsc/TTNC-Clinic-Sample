using Sample.Entities;

namespace Sample.Services;

public class UserService : IUserService
{
    public UserService()
    {
    }

    public Task<string?> GetCurrentUserAsync()
    {
        throw new NotImplementedException();
    }
}
