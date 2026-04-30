using ContactServiceGP.Application.Commands;
using ContactServiceGP.Application.Mappers;
using ContactServiceGP.Domain.Interfaces;
using ContactServiceGP.Infrastructure.Configurations;
using ContactServiceGP.Infrastructure.Data;
using ContactServiceGP.Infrastructure.Repositories;
using ContactServiceGP.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar EF Core con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(Program).Assembly,
    typeof(SendEmailCommand).Assembly
));

builder.Services.AddAutoMapper(cfg => {}, typeof(ConfigurationMapper).Assembly);

// Agregar las interfaces y clases que se inyectarán
builder.Services.AddTransient<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings")
);

var corsOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
    policy =>
    {
        policy.WithOrigins(corsOrigins);
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

// Solo usa Swagger (compatible con .NET 8)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
