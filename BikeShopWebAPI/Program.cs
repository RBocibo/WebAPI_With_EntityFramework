using BikeShop.Entities.Data;
using Microsoft.EntityFrameworkCore;
using LoggerService;
using Contracts;
using MediatR;
using System.Reflection;
using BikeShop.Entities.Handlers;
using BikeShop.Entities.Extensions;



//var builder = WebApplication.CreateBuilder(args);

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});


// Add services to the container.
builder.Services.AddJWTTokenServices(builder.Configuration);

// Add services to the container/ Register Context class into IoC.

builder.Services.AddDbContext<BikeShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    
});

//Add MediatR to our project’s DI container and pass the assembly that would contain the commands, queries, and handlers

//builder.Services.AddMediatR(typeof(GetBrandHandler).Assembly);
builder.Services.AddMediatR(typeof(BikeShop.Entities.AssemblyReference).Assembly);

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
