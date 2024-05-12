using Common.Logging;
using HealthCare.Infrastructure.DI.Services;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
DateTime startTime = DateTime.Now;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthCareService();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(Assembly.Load("HealthCare.Application"));
}, typeof(Program));


// Configure Serilog
builder.Host.UseSerilog(Logging.ConfigureLogger);



var app = builder.Build();

GlobalContext.Initialize(app.Services);
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => {
   
    TimeSpan uptime = DateTime.Now - startTime;
    // Log the system info
    //Log.Information($"System info: HealthCare Api Server is Running {uptime.Hours} hour {uptime.Minutes} minute {uptime.Seconds} second and {uptime.Milliseconds} millisecond");
    return $"HealthCare Api Server is Running {uptime.Hours} hour {uptime.Minutes} minute {uptime.Seconds} second and {uptime.Milliseconds} millisecond";
}).ExcludeFromDescription();

app.Run();

