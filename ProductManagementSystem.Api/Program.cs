using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Application;
using ProductManagementSystem.Application.Behaviors;
using ProductManagementSystem.Application.Commands.CreateProduct;
using ProductManagementSystem.Domain.Interfaces;
using ProductManagementSystem.Infrastructure;
using ProductManagementSystem.Infrastructure.Persistence;
using ProductManagementSystem.Infrastructure.Repositories;
using ProductManagementSystem.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddApplicationLayer();

builder.Services.AddInfrastructureLayer();

builder.Services.AddLogging();

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
