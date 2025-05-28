using AnurakStillLife.API.Extensions;
using Core.Entities.Identity;
using Infrastructure;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

//var keyVaultEndpoint = new Uri(builder.Configuration.GetSection("KeyVaultUri").Value);
//if (builder.Environment.IsDevelopment())
//{
//    builder.Configuration.AddAzureKeyVault(new Uri(builder.Configuration.GetSection("KeyVaultUri").Value), new DefaultAzureCredential());
//}

// Add services to the container.
IServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
var service = serviceProvider.GetService<IKeyVaultManager>();
var connectionString = service.GetVaultSecret(builder.Configuration.GetSection("SecretKey").Value).Result;
builder.Services.AddDbContext<StillLifeContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentityServices(builder.Configuration, connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseDefaultFiles();
app.UseStaticFiles();

//app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StillLifeContext>();
var identityContext = services.GetRequiredService<AppIdentityDbContext>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await identityContext.Database.MigrateAsync();
    await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
