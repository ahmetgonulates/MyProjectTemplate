using Microsoft.Extensions.DependencyInjection;
using MyProjectTemplate.Application.Services.InfrastructureServices;
using MyProjectTemplate.Infrastructure.Services;

namespace MyProjectTemplate.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, JwtTokenService>();
        
        
        return services;
    }
}
