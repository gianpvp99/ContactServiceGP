using ContactServiceGP.Application.Commands;
using ContactServiceGP.Application.Mappers;
using ContactServiceGP.Domain.Interfaces;
using ContactServiceGP.Infrastructure.Data;
using ContactServiceGP.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
