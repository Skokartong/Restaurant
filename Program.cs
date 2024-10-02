using Restaurant.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.IServices;
using Restaurant.Services;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Data.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Loading Environment variables
Env.Load();

// Adding DbContext in our DI-container 
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection")));

builder.Configuration.AddEnvironmentVariables(); 

var key = builder.Configuration["JwtKey"];
var issuer = builder.Configuration["JwtIssuer"];
var audience = builder.Configuration["JwtAudience"];

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        };
    });

// CORS-config to allow cross origin access
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientAppCorsPolicy",
        builder => builder.WithOrigins("https://localhost:7135/")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddAuthorization();

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
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("ClientAppCorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

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
