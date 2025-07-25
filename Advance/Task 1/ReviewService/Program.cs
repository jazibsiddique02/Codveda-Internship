using Consul;
using Grpc.Net.Client;
using ReviewService.Config;
using ReviewService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IReviewRepository, ReviewRepository>();



// Configure gRPC client to call ProductService
builder.Services.AddSingleton(provider =>
{
    var channel = Grpc.Net.Client.GrpcChannel.ForAddress("https://localhost:7299");
    return new ProductService.Grpc.ProductGrpc.ProductGrpcClient(channel);
});



// Load from config or hardcode for now
var consulConfig = new ConsulConfig
{
    ServiceName = "ReviewService", 
    ServiceId = "review-service-1",
    ServiceAddress = "https://localhost",
    ServicePort = 7297 
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



app.MapControllers();

app.Run();
