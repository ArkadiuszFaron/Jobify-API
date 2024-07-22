using Jobify.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Jobify.Api.Registers;

public static class RegisterStartupServices
{
    public static WebApplicationBuilder RegisterServices(
        this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(_ =>
        {
            _.CustomSchemaIds(x => x.FullName);
            _.SwaggerDoc("current", new OpenApiInfo
            {
                Title = "Jobify API",
                Version = Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString()
            });
            _.DocInclusionPredicate((d, api) => !string.IsNullOrWhiteSpace(api.GroupName));
            _.TagActionsBy(api => new List<string?> { api.GroupName });
        });

        builder.Services.AddDbContext<JobifyContext>(
            _ =>
            {
                _.UseSqlServer(configuration.GetConnectionString("Jobify"),
                    sqlServerOptions => sqlServerOptions.CommandTimeout(120));
            }, contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Singleton);

        builder.Services.AddDbContextFactory<JobifyContext>(
            _ =>
            {
                _.UseSqlServer(configuration.GetConnectionString("Jobify"),
                    sqlServerOptions => sqlServerOptions.CommandTimeout(120));
            }, ServiceLifetime.Scoped);

        return builder;
    }
}