using Serilog;
using Tech_Store_Product_Service_Application.Extensions;
using Tech_Store_Product_Service_Infrastructure.Extensions;
using Tech_Store_Product_Service_Presentation.Extensions;
using Tech_Store_Product_Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerDocumentation();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices(builder.Configuration);

// Add logging with Serilog
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.UseInfrastructureSwagger();

app.MapControllers();

app.MapApplicationHealthChecks();

app.Run();
