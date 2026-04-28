using Microsoft.EntityFrameworkCore;
using Roblocks.Config;
using Roblocks.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var appConfig = new AppConfig();
builder.Configuration.Bind(appConfig);
builder.Services.AddSingleton(appConfig);

builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(appConfig.Database.ConnectionString, ServerVersion.AutoDetect(appConfig.Database.ConnectionString)));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    Console.WriteLine("Applying Migrations");
    dbContext.Database.Migrate();
    Console.WriteLine("Migrations applied");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();