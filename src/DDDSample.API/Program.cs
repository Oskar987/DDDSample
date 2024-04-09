using DDDSample.API;
using DDDSample.Infrastructure;
using DDDSample.Application;
using DDDSample.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
} 

app.UseAuthorization();

app.MapControllers();

app.Run();

