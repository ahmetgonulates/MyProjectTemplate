using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyProjectTemplate.Infrastructure;
using MyProjectTemplate.Persistance;
using MyProjectTemplate.Application;
using MyProjectTemplate.Domain.Exceptions;
using MyProjectTemplate.Infrastructure.Configurations;
using MyProjectTemplate.WebAPI.Handlers;

namespace MyProjectTemplate.WebAPI;

public static class ConfigurationServices
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.ConfigureOptionsPattern(configuration);
        
        services.AddOpenApi();
        
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        services.AddPersistanceServices(configuration);

        services.ConfigureAuthentication(configuration);
        services.ConfigureExceptionHandler();
        
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
    
    private static void ConfigureExceptionHandler(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState.FirstOrDefault(x => x.Value.Errors.Count > 0);
                throw new BadRequestException("400999", errors.Value.Errors[0].ErrorMessage);
            };
        });
        services.AddExceptionHandler<ExceptionHandler>();
    }
    
    private static void ConfigureOptionsPattern(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
    }
}