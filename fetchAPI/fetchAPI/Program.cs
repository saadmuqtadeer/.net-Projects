var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string policyName = "CorsPolicy";

builder.Services.AddControllers();
//cross origin resourse share(CORS) wont allow two ports/servers to communicate with each other on same machine 
builder.Services.AddCors(options => {
    options.AddPolicy(name: policyName, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors(policyName);

app.MapControllers();

app.Run();
