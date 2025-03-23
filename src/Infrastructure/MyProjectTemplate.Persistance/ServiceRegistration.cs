using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyProjectTemplate.Persistance;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}
