using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sample.Extensions;

namespace Sample.Pages;

public class LoginModel : PageModel
{
    private readonly IConfiguration configuration;

    public LoginModel(IConfiguration configuration) =>
        this.configuration = configuration;

    public async Task OnGet(string redirectUri)
    {
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(redirectUri ?? "/")
            .Build();

        if (configuration.IsUnderProxy())
        {
            HttpContext.Request.IsHttps = true;
        }
        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    }
}
