using GlobalExceptionHandling.Extensions;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.

var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.ConfigureExceptionHandler(logger);

app.UseAuthorization();

app.MapControllers();

app.Run();
