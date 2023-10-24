namespace Sample.Extensions;

public static class ConfigurationExtensions
{
    public static string GetAuth0Domain(this IConfiguration configuration) =>
        configuration["Auth0:Domain"] ?? throw new Exception("[Auth0:Domain] config is missing");

    public static string GetAuth0ClientId(this IConfiguration configuration) =>
        configuration["Auth0:ClientId"] ?? throw new Exception("[Auth0:ClientId] config is missing");

    public static string GetReportConnection(this IConfiguration configuration) =>
        configuration["ConnectionStrings:Connection"] ?? throw new Exception("[ConnectionStrings:Connection] config is missing");
}
