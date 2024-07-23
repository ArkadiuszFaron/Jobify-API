using Jobify.Api.Clients;
using Jobify.Api.Profiles;
using Jobify.Api.Services;
using Jobify.Common.Configs;
using Jobify.Domain.Contexts;
using Jobify.Domain.Repositories;
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

        builder.Services.AddAutoMapper(typeof(DomainToDtoProfile));
        builder.Services.AddAutoMapper(typeof(DtoToDomainProfile));
        builder.Services.AddAutoMapper(typeof(ModelToDtoProfile));

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
        
        builder.Services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        builder.Services.Configure<JobicyApiConfig>(configuration.GetSection("JobicyApiConfig"));

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
        
        builder.Services.AddSingleton<IDapperRepository>(_ =>
            new DapperRepository(configuration.GetConnectionString("Jobify")));

        builder.Services.AddScoped<IJobicyApiClient, JobicyApiClient>();
        
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IIndustryService, IndustryService>();
        builder.Services.AddScoped<IJobService, JobService>();

        return builder;
    }
}