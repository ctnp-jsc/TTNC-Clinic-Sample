using Auth0.AspNetCore.Authentication;
using DevExpress.DataAccess.Web;
using DevExpress.DataAccess.Wizard.Services;
using Microsoft.EntityFrameworkCore;
using Sample.Entities;
using Sample.Interceptors;
using Sample.Reports;
using Sample.Repositories;
using Sample.Services;

namespace Sample.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.AddPooledDbContextFactory<EntityDbContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), o => o
                .MigrationsAssembly("Sample.Migrations")
                .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                .EnableRetryOnFailure()
            )
            .EnableServiceProviderCaching()
            .AddInterceptors(new AuditInterceptor(), new SoftDeleteInterceptor())
        );
        @this.AddScoped<EntityDbContextFactory>();
        @this.AddScoped(sp => sp.GetRequiredService<EntityDbContextFactory>().CreateDbContext());

        @this.AddAutoMapper(typeof(Program).Assembly);

        @this.AddAuth0WebAppAuthentication(options =>
        {
            options.Domain = configuration.GetAuth0Domain();
            options.ClientId = configuration.GetAuth0ClientId();
        });

        @this.AddRepositories().AddServices();

        return @this;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection @this) => @this
        .AddScoped<IFormRepository, FormRepository>();

    public static IServiceCollection AddServices(this IServiceCollection @this) => @this
        .AddScoped<IConnectionProviderFactory, ConnectionProviderFactory>()
        .AddScoped<IConnectionProviderService, ConnectionProviderService>()
        .AddScoped<IUnitOfWork, UnitOfWork<EntityDbContext>>()
        .AddScoped<IUserService, UserService>()
        .AddScoped<FormService>();

}
