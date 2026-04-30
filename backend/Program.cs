using System.Text;
using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MySqlConnector;
using Roblocks.Config;
using Roblocks.Database;
using Roblocks.Database.services.gamesServices;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Roblocks.Database.services.userServices;
using Roblocks.MappingProfiles;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Roblocks.Database.services.AuthServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// Add services to the container.

var appConfig = new AppConfig();
builder.Configuration.Bind(appConfig);
builder.Services.AddSingleton(appConfig);

builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(appConfig.Database.ConnectionString, ServerVersion.AutoDetect(appConfig.Database.ConnectionString)));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<GamesServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<AuthServices>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT_SECRET"]!)
            ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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

builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
            factory: partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 10,
                QueueLimit = 0,
                Window = TimeSpan.FromMinutes(1)
            }));

    options.AddFixedWindowLimiter("strict", opt =>
    {
        opt.AutoReplenishment = true;
        opt.PermitLimit = 3;
        opt.QueueLimit = 0;
        opt.Window = TimeSpan.FromMinutes(1);
    });
});

builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
builder.Services.AddScoped<IAuthService, AuthServices>();

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
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

