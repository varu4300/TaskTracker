using Asp.Versioning;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using TaskTracker.Api.Configs;
using TaskTracker.Api.Models.Requests;
using TaskTracker.Api.Utilities.Filters;
using TaskTracker.Api.Utilities.Helpers;
using TaskTracker.Api.Validators;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Services;
using TaskTracker.Domain.Interfaces;
using TaskTracker.Infrastructure.Data;
using TaskTracker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<TaskItemProfile>();
}, typeof(Program));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Task Tracker API",
        Version = "v1"
    });
});

// Injecting services and repository as Scoped services
// Lifetime of containers should only span for every HTTP Request
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskItemService, TaskItemService>();
builder.Services.AddValidatorsFromAssemblyContaining<TaskItemRequestValidator>();
builder.Services.AddScoped<CustomValidation<CreateTaskItemRequest>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.RoutePrefix = string.Empty; // Swagger at root "/"
       
    });
    
   
    // Auto-generate migration files
    // Only want this for development purposes only
    // This should not be used in production
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }
}



// Configure the cultures your API supports
// Can add language for translations 
// Adding for error validation messages
var configuredCultures = new[] { "en" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(configuredCultures)
    .AddSupportedUICultures(configuredCultures);
app.UseHttpsRedirection();
app.UseRequestLocalization(localizationOptions);
app.MapControllers();

app.Run();
