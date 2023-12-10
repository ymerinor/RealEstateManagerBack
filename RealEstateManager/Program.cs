using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RealEstateManager.Application.Owners.Interface;
using RealEstateManager.Application.Owners.Service;
using RealEstateManager.Application.PopertyImages.Interfaces;
using RealEstateManager.Application.PopertyImages.Services;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.Application.Propertys.Services;
using RealEstateManager.Application.Propertys.Validations;
using RealEstateManager.Domain.FilesManager;
using RealEstateManager.Domain.Repository;
using RealEstateManager.Infrastructure;
using RealEstateManager.Infrastructure.FilesManager;
using RealEstateManager.Infrastructure.Repository;
using RealEstateManager.Middleware;
using Serilog;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<RealEstateManagerDbContext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("RealEstateConnection")));
builder.Services.AddTransient<IPropertyRepository, PropertyRepository>();
builder.Services.AddTransient<IOwnerRepository, OwnerRepository>();
builder.Services.AddTransient<IPropertyImageRepository, PropertyImageRepository>();
builder.Services.AddTransient<IFilesManager, FilesManagerAdapter>();
ConfigureServices(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

//Add support to logging request with SERILOG
app.UseSerilogRequestLogging();
app.UseResponseTimeLogging();
app.UseExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

[ExcludeFromCodeCoverage]
void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IPropertyService, PropertyService>();
    services.AddTransient<IPropertyImageService, PropertyImageService>();
    services.AddTransient<IOwnerService, OwnerService>();
    builder.Services.AddScoped<IValidator<PropertyRequestDto>, PropertyRequestValidator>();
}
