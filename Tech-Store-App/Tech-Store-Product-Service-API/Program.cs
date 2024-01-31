using Microsoft.EntityFrameworkCore;
using Serilog;
using Tech_Store_Product_Service_Application.Extensions;
using Tech_Store_Product_Service_Infrastructure.DataContexts;
using Tech_Store_Product_Service_Infrastructure.Extensions;
using Tech_Store_Product_Service_Infrastructure.SeedData.Initializer;
using Tech_Store_Product_Service_Presentation.Extensions;
using Tech_Store_Product_Service.Extensions;
using Tech_Store_Product_Service.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add logging with Serilog
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddSwaggerDocumentation();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseInfrastructureSwagger();

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseSerilogRequestLogging();

app.MapControllers();

app.MapApplicationHealthChecks();

// Auto applying new migrations at build+run, or creating the DB otherwise + initial seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationContext>();
    var dataContextSeed = services.GetRequiredService<IDataContextSeed>();
    var env = services.GetRequiredService<IHostEnvironment>();
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Starting Context Initializer.");
        await context.Database.MigrateAsync();
        await dataContextSeed.SeedAsync(context, env);
    }
    catch (Exception e)
    {
        logger.LogInformation("An error occured during migration, or seed!");
    }
}

app.Run();
