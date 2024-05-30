using DDDSample.API;
using DDDSample.Infrastructure;
using DDDSample.Application;
using DDDSample.API.Extensions;
using DDDSample.API.Middlewares;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddPresentation(builder.Configuration)
            .AddInfrastructure(builder.Configuration)
            .AddApplication();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            await app.ApplyMigrations();
        }

        app.UseExceptionHandler("/error");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<GloblalExceptionHandlingMiddleware>();
        app.MapControllers();

        app.Run();
    }
}

