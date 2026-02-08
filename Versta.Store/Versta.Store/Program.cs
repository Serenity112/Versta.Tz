using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;
using Versta.Store.Endpoints;
using Versta.Store.Exceptions.Domain;
using Versta.Store.Handlers.Order.Create;
using Versta.Store.Handlers.Order.History;
using Versta.Store.Infrastructure;
using Versta.Store.Infrastructure.Repository.Order;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("Postgres")!;
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderHistoryHandler, OrderHistoryHandler>();
builder.Services.AddScoped<ICreateOrderHandler, CreateOrderHandler>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Host.UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddValidation();
builder.Services.AddExceptionHandler<DomainExceptionHandler>();

var app = builder.Build();

app.MapApiEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors();
app.UseExceptionHandler();
app.UseStatusCodePages();

app.Run();
