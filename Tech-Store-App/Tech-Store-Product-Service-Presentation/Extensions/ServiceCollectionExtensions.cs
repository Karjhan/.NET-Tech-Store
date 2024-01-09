using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tech_Store_Product_Service_Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMvc().AddApplicationPart(Assembly.Load(Assembly.GetExecutingAssembly().GetName()));
        
        return services;
    }
}