using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tech_Store_Product_Service_Infrastructure.Configuration;
using Tech_Store_Product_Service_Infrastructure.DataContexts;
using Tech_Store_Product_Service_Infrastructure.HealthChecks;
using Tech_Store_Product_Service_Infrastructure.SeedData.Initializer;

namespace Tech_Store_Product_Service_Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add Swagger 
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        // Add Seed Data configuration
        services.Configure<SeedDataConfiguration>(configuration.GetSection(nameof(SeedDataConfiguration)).Bind);
        
        // Add Seed Data initializer
        services.AddScoped<IDataContextSeed, DataContextSeed>();
        
        // Add EF Core configuration
        services.Configure<EFConfiguration>(configuration.GetSection(nameof(EFConfiguration)).Bind);

        var efConfiguration = configuration.GetSection(nameof(EFConfiguration)).Get<EFConfiguration>();
        
        // Add health checks
        services.AddHealthChecks()
            .AddCheck<ApplicationHealthCheck>("Product-Service-App")
            .AddNpgSql(efConfiguration!.ConnectionString);
        
        // Add entity dbContext for app, add postgres connection for dbContext
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(efConfiguration.ConnectionString);
        });
        
        // Add CORS
        services.AddCors(options =>
        {
            options.AddPolicy("DefaultCorsPolicy", policy =>
            {
                var origins = configuration.GetSection("AllowedOrigins").Get<string[]>();
                if (origins?.Length > 0)
                {
                    policy
                        .WithOrigins(origins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
                else
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            });
        });
        
        return services;
    }
}