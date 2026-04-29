using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Roblocks.Config;
using Roblocks.Database;
using Roblocks.Database.services.gamesServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var appConfig = new AppConfig();
builder.Configuration.Bind(appConfig);
builder.Services.AddSingleton(appConfig);

builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(appConfig.Database.ConnectionString, ServerVersion.AutoDetect(appConfig.Database.ConnectionString)));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<GamesService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    Console.WriteLine("Applying Migrations");
    dbContext.Database.Migrate();
    Console.WriteLine("Migrations applied");
    
}
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

Console.WriteLine(appConfig.Database.ConnectionString);
// Configure the HTTP request pipeline.
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();