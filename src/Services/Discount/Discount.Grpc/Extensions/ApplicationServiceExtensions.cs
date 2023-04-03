using AutoMapper;
using Discount.Grpc.Repositories;

namespace Discount.Grpc.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddGrpc();

            return services;
        }
    }
}