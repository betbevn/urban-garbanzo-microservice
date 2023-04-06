using System.Reflection;
using EventBus.Messages.Common;
using MassTransit;
using Microsoft.OpenApi.Models;
using Ordering.API.EventBusConsumer;
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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(configMassTransit =>
            {
                // Consumer
                configMassTransit.AddConsumer<BasketCheckoutConsumer>();

                configMassTransit.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(config["EventBusSettings:HostAddress"]);
                    cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
                    {
                        c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
                    });
                });
            });

            return services;
        }
    }
}