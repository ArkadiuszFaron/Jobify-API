using Jobify.Api.Registers;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true)
    .AddEnvironmentVariables()
    .Build() as IConfiguration;

WebApplication.CreateBuilder(args)
    .RegisterServices(configuration)
    .Build()
    .SetupMiddleware(configuration)
    .Run();