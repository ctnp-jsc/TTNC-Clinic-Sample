using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.Entities;
using Sample.Interceptors;
using Ulrich.Micro.PWPay.API.Entities;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<EntityDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o
        .MigrationsAssembly("Ulrich.Micro.PWPay.API.Migrations")
        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
        .EnableRetryOnFailure()
    )
    .EnableServiceProviderCaching()
    .AddInterceptors(new AuditInterceptor(), new SoftDeleteInterceptor())
);
builder.Services.AddScoped<EntityDbContextFactory>();
builder.Services.AddScoped(sp => sp.GetRequiredService<EntityDbContextFactory>().CreateDbContext());

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
