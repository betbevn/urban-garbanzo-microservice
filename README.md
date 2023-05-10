# urban-garbanzo-microservice

**Catalog**

Nuget: MongoDB.Driver
Docker: Add --> Container Orchestrator Support --> Docker Compose --> Linux --> Ok

**Basket**

docker run -d -p 6379:6379 --name aspnetrun-redis redis

Grpc.AspNetCore
Microsoft.Extensions.Caching.StackExchangeRedis
Newtonsoft.Json --> Dùng để chuyển string thành object (Bởi redis lưu là string)
MassTransit
MassTransit.RabbitMQ
MassTransit.AspNetCore

portainer: admin/F@mVGAD7vdP6TKy

Giữa Basket.API và Discount.Grpc giao tiếp với nhau bằng GPRC:

Để sử dụng dữ liệu từ Discount service từ Basket cần làm những bước sau đây

- Thêm Service Reference trên Basket.API
- Add --> **Connected service** --> GRPC --> Next --> Select the type of class to be generated (client)
- Tạo DiscountGrpcService để định nghĩa các phương thức phía Client (Basket.API)
- Register Discount Grpc CLient và Discount Grpc Service vào trong Basket.API

```C#
services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = config.GetValue<string>("CacheSettings:ConnectionString");
});
```

Docker: Add --> Container Orchestrator Support --> Docker Compose --> Linux --> Ok

**Discount.API**

Npgsql
Dapper
Docker: Add --> Container Orchestrator Support --> Docker Compose --> Linux --> Ok

**Discount.Grpc**

AutoMapper.Extensions.Microsoft.DependencyInjection
Npgsql
Dapper
Docker: Add --> Container Orchestrator Support --> Docker Compose --> Linux --> Ok

**Ordering**

MediatR.Extentions.Microsoft.DependencyInjection
FluentValidation
FluentValidation.DependencyInjectionExtensions
AutoMapper
AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.Extentions.Logging.Abstractions
Microsoft.EntityFrameworkCore.SqlServer
SendGrid
Microsoft.EntityFrameworkCore.Tools

```bash
dotnet ef migrations add InitialCreate -o Migrations -s ../Ordering.API/Ordering.API.csproj
```

Ordering.API sẽ được tổ chức theo Domain-Driven Design (DDD). Vì vậy bên cạnh một project chính Ordering.API, ta sẽ có các project vệ tinh (ClassLibrary) xung quoanh để phục vụ cho việc định nghĩa các entity, kết nối database (infrastruture), cấu hình,...

- Tạo project chính Ordering.API
- Tạo các projects ClassLibrary như: Ordering.Domain, Ordering.Application, Ordering.Infrastructure,...
- Adding Project References Between Clean Architecture Layers
  - Application (CQRS) --ReferenceTo--> Domain (Entities)
  - Infrastructure --ReferenceTo--> Application
  - Ordering.API --ReferenceTo--> Application
  - Ordering.API --ReferenceTo--> Infrastructure

**RabitMQ & MassTransit**

```yml

rabbitmq:
  image: rabbitmq:3-management-alpine

rabbitmq:
  container_name: rabbitmq
  restart: always
  ports:
      - "5672:5672"
      - "15672:15672"

```

- Tạo Thư mục BuildingBlocks
- Tạo một project ClassLibrary trong thư mục BuildingBlocks có tên EventBus.Messages
- Sau đó, nếu microservice nào cần consume/subscribe thí sẽ cấu hình trên service đó

  - Publish RabbitMQ trên Basket.API

  ```C#
  			// MassTransit-RabbitMQ Configuration
        services.AddMassTransit(configuration => {
          configuration.UsingRabbitMq((ctx, cfg) => {
            cfg.Host(config["EventBusSettings:HostAddress"]);
          });
        });
        services.AddMassTransitHostedService();
  ```

  - Consume RabbitMQ Event

  ```C#
  			// MassTransit-RabbitMQ Configuration
        builder.Services.AddMassTransit(configuration =>
        {
          configuration.AddConsumer<BasketCheckoutConsumer>();
          configuration.UsingRabbitMq((ctx, cfg) =>
          {
            cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
            cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
            {
              c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
            });
          });
        });
        builder.Services.AddMassTransitHostedService();
  ```

  **Gateways with Ocelot**

  - Routing
  - Request Agreegation
  - Service Discovery with Consul & Eureka
  - Loading Balancing
  - Correlation Pass-Through
  - Quality of Service
  - Authentication
  - Authorization
  - Throttling
  - Logging, Tracing
  - Headers/Query String Transformation
  - Custom Middleware

```
run-aspnet-identityserver4
```

Nuget: Ocelot
