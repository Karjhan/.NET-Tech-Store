using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tech_Store_Product_Service_Domain.Extensions;

namespace Tech_Store_Product_Service_Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDomainServices(configuration);
        
        return services;
    }
}