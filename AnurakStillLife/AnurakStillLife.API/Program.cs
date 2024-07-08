using Core.Interface;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IKeyVaultManager, KeyVaultManager>();
builder.Services.AddScoped<IArtWorkRepository, ArtWorkRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//var keyVaultEndpoint = new Uri(builder.Configuration.GetSection("KeyVaultUri").Value);
//if (builder.Environment.IsDevelopment())
//{
//    builder.Configuration.AddAzureKeyVault(new Uri(builder.Configuration.GetSection("KeyVaultUri").Value), new DefaultAzureCredential());
//}

// Add services to the container.
builder.Services.AddDbContext<StillLifeContext>(options =>
{
    IServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
    var service = serviceProvider.GetService<IKeyVaultManager>();
    var connectionString = service.GetVaultSecret().Result;
    options.UseSqlServer(connectionString);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StillLifeContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
