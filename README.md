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

**Discount**

Npgsql
Dapper

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
