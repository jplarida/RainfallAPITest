using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Common.Services;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:3000");
builder.Configuration.AddJsonFile("appsettings.json");

// Read the API version from configuration
var apiVersion = "v1";//builder.Configuration["ApiVersion"];

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("RainfallDatabase"); // Database name
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(apiVersion, new OpenApiInfo { Title = "TEST RAINFALL", Version = apiVersion });
});
builder.Services.AddScoped<Common.Interfeces.IRainfallService, RainFallAPI.Services.RainfallService>();

builder.Services.AddControllers();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/{apiVersion}/swagger.json", $"TEST RAINFALL - {apiVersion}");
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();

    dbContext.Database.EnsureCreated(); // Ensure the database is created

    // Seed sample data if needed
    SampleData.Initialize(dbContext);
}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
