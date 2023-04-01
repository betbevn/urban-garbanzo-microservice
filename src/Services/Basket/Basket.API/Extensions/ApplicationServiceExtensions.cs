using Basket.API.Repositories;
using Microsoft.OpenApi.Models;

namespace Basket.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config.GetValue<string>("CacheSettings:ConnectionString");
            });
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
            });

            return services;
        }
    }
}