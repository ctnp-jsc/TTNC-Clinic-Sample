using Microsoft.AspNetCore.Components.Authorization;
using Sample.Entities;
using System.Security.Claims;

namespace Sample.Services;

public class UserService : IUserService
{
    private readonly AuthenticationStateProvider stateProvider;

    public UserService(AuthenticationStateProvider stateProvider)
    {
        this.stateProvider = stateProvider;
    }

    public async Task<string?> GetCurrentUserAsync()
    {
        var state = await stateProvider.GetAuthenticationStateAsync();
        return state.User?.FindFirst(ClaimTypes.Name)?.Value;
    }
}
