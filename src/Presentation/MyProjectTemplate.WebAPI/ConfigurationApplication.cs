using Scalar.AspNetCore;

namespace MyProjectTemplate.WebAPI;

public static class ConfigurationApplication
{
    public static IApplicationBuilder ConfigureApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}