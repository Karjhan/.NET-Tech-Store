using Microsoft.AspNetCore.Builder;

namespace Tech_Store_Product_Service_Infrastructure.Extensions;

public static class AppExtensionMethods
{
    public static WebApplication UseInfrastructureSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors();

        return app;
    }
}