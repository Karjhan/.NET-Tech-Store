using Microsoft.Extensions.Hosting;
using Tech_Store_Product_Service_Infrastructure.DataContexts;

namespace Tech_Store_Product_Service_Infrastructure.SeedData.Initializer;

public interface IDataContextSeed
{
    Task SeedAsync(ApplicationContext context, IHostEnvironment environment);
}