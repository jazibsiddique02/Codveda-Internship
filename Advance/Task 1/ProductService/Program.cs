using Consul;
using ProductService.Config;
using ProductService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddGrpc();



// Load from config or hardcode for now
var consulConfig = new ConsulConfig
{
    ServiceName = "ProductService", 
    ServiceId = "product-service-1",
    ServiceAddress = "https://localhost",
    ServicePort = 7299
};

builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
{
    cfg.Address = new Uri("http://localhost:8500");
}));



var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(() =>
{
    var registration = new AgentServiceRegistration()
    {
        ID = consulConfig.ServiceId,
        Name = consulConfig.ServiceName,
        Address = "localhost",
        Port = consulConfig.ServicePort,
        Check = new AgentServiceCheck
        {
            HTTP = $"{consulConfig.ServiceAddress}:{consulConfig.ServicePort}/health",
            Interval = TimeSpan.FromSeconds(10),
            Timeout = TimeSpan.FromSeconds(5),
            DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(1)
        }
    };

    using var scope = app.Services.CreateScope();
    var consul = scope.ServiceProvider.GetRequiredService<IConsulClient>();
    consul.Agent.ServiceRegister(registration).Wait();
});

app.Lifetime.ApplicationStopped.Register(() =>
{
    using var scope = app.Services.CreateScope();
    var consul = scope.ServiceProvider.GetRequiredService<IConsulClient>();
    consul.Agent.ServiceDeregister(consulConfig.ServiceId).Wait();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGrpcService<ProductService.Services.ProductGrpcService>();


app.MapControllers();

app.Run();
