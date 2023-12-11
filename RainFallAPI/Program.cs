using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:3000");

// Add services to the container as well as external services since we are on distributed microserviced system.
builder.Services.AddSingleton<Common.Interfeces.IRainfallService, RainFallAPI.Services.RainfallService>();

// Configure the services and controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

// UseEndpoints should be used instead of MapControllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();