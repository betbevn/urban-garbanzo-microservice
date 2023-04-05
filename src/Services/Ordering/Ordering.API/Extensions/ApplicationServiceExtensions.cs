using Microsoft.OpenApi.Models;
using Ordering.Application;
using Ordering.Infrastructure;

namespace Ordering.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering.API", Version = "v1" });
            });
            services.AddApplicationServicesRegistration();
            services.AddInfrastructureServices(config);

            return services;
        }
    }
}