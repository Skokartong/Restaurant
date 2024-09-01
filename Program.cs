using Restaurant.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.IServices;
using Restaurant.Services;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Data.Repos;

var builder = WebApplication.CreateBuilder(args);

// Loading Environment variables
Env.Load();

// Adding DbContext in our DI-container 
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IOrderMenuService, OrderMenuService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
