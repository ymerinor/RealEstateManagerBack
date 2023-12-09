using Microsoft.EntityFrameworkCore;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.Application.Propertys.Services;
using RealEstateManager.Domain.Repository;
using RealEstateManager.Infrastructure;
using RealEstateManager.Infrastructure.Repository;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<RealEstateManagerDbContext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("RealEstateConnection")));
builder.Services.AddTransient<IPropertyRepository, PropertyRepository>();
ConfigureServices(builder.Services);
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

[ExcludeFromCodeCoverage]
void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IPropertyService, PropertyService>();

}
