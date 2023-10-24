using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sample.Extensions;

namespace Sample.Pages;

public class LogoutModel : PageModel
{
    private readonly IConfiguration configuration;

    public LogoutModel(IConfiguration configuration) =>
        this.configuration = configuration;

    [Authorize]
    public async Task OnGetAsync()
    {
        var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
           .WithRedirectUri("/")
           .Build();
        if (configuration.IsUnderProxy())
        {
            HttpContext.Request.IsHttps = true;
        }
        await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
