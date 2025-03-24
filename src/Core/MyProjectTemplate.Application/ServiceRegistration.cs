using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyProjectTemplate.Application.Behaviors;

namespace MyProjectTemplate.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.ConfigureMediatR();
        services.ConfigureAutoMapper();
        services.ConfigureFluentValidation();
        
        return services;
    }

    private static void ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));
    }

    private static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AssemblyReference).Assembly);
    }
    
    private static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehaviors<,>)));
    }
}
