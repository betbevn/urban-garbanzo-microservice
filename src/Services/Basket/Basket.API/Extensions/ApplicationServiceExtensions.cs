using System.Reflection;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using MassTransit;
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
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
                (o => o.Address = new Uri(config["GrpcSettings:DiscountUrl"]));
            services.AddScoped<DiscountGrpcService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(configMassTransit =>
            {
                configMassTransit.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(config["EventBusSettings:HostAddress"]);
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
            });

            return services;
        }
    }
}