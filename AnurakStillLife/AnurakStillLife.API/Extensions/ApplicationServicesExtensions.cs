using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Services;

namespace AnurakStillLife.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
    IConfiguration config)
        {
            services.AddScoped<IKeyVaultManager, KeyVaultManager>();
            services.AddScoped<IArtWorkRepository, ArtWorkRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });

            return services;
        }
    }
}
