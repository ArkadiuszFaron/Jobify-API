namespace Jobify.Api.Registers;

public static class RegisterStartupMiddlewares
{
    public static WebApplication SetupMiddleware(
        this WebApplication app,
        IConfiguration configuration)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(_ => { _.SwaggerEndpoint("/swagger/current/swagger.json", "Jobify API"); });
        }
        else
        {
            app.UseHsts();
        }

        app.UseCors(_ => _
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader()
            .WithOrigins(configuration.GetValue<string>("Cors:AllowOrigins")?.Split(',')));

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}