using Microsoft.EntityFrameworkCore;
using MiniProductCatalog.DataAccess.Data;
using MiniProductCatalog.DataAccess.Repository;
using MiniProductCatalog.DataAccess.Repository.Interface;
using MiniProductCatalog.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console() // Log to console
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning) // Ignore Microsoft info logs
    .Filter.ByIncludingOnly(logEvent =>
        logEvent.MessageTemplate.Text.Contains("Request to")) // Only log your navigation logs
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Host.UseSerilog();


// Add services to the container.
builder.Services.AddControllersWithViews();

// add context to service container
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));


// add UnitOfWork to the services container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<RequestTimingMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
