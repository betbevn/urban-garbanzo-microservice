using Discount.API.Repositories;
using Microsoft.OpenApi.Models;

namespace Discount.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Discount.API", Version = "v1" });
            });

            services.AddScoped<IDiscountRepository, DiscountRepository>();

            return services;
        }
    }
}