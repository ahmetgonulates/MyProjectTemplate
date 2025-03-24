using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using MyProjectTemplate.Infrastructure;
using MyProjectTemplate.Persistance;
using MyProjectTemplate.Presentation;
using MyProjectTemplate.Application;
using MyProjectTemplate.WebAPI.Handlers;

namespace MyProjectTemplate.WebAPI;

public static class ConfigurationServices
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers().AddApplicationPart(typeof(MyProjectTemplate.Presentation.AssemblyReference).Assembly);

        services.AddOpenApi();
        
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        services.AddPersistanceServices(configuration);

        services.ConfigureAuthentication(configuration);
        
        return services;
    }

    private static IServiceCollection ConfigureAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true; 
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });

        services.AddAuthorization();

        services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationMiddlewareResultHandler>();

        return services;
    }
}