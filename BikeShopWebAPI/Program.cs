using BikeShop.Entities.Data;
using Microsoft.EntityFrameworkCore;
using LoggerService;
using Contracts;
using MediatR;
using System.Reflection;
using BikeShop.Entities.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container/ Register Context class into IoC.

builder.Services.AddDbContext<BikeShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    
});

//Add MediatR to our project’s DI container and pass the assembly that would contain the commands, queries, and handlers

builder.Services.AddMediatR(typeof(GetBrandHandler).Assembly);

// Registering Logging service to the container
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
