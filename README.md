# urban-garbanzo-microservice

**Catalog**

Nuget: MongoDB.Driver
Docker: Add --> Container Orchestrator Support --> Docker Compose --> Linux --> Ok

**Basket**

docker run -d -p 6379:6379 --name aspnetrun-redis redis

Grpc.AspNetCore
Microsoft.Extensions.Caching.StackExchangeRedis
Newtonsoft.Json --> Dùng để chuyển string thành object (Bởi redis lưu là string)

portainer: admin/F@mVGAD7vdP6TKy

Giữa Basket.API và Discount.Grpc giao tiếp với nhau bằng GPRC:

Để sử dụng dữ liệu từ Discount service từ Basket cần làm những bước sau đây

- Thêm Service Reference trên Basket.API
- Add --> Connected service --> GRPC --> Next --> Select the type of class to be generated (client)
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
