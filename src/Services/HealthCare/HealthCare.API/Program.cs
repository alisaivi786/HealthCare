

using HealthCare.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
DateTime startTime = DateTime.Now;
// Add services to the container.

IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthCareServices(configuration);
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

