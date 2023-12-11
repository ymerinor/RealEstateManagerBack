using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RealEstateManager.Api.Middleware;
using RealEstateManager.Application.Authenication;
using RealEstateManager.Application.Authentication;
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
using Serilog;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Real Estate Manager.",
        Description = "Demo API - para el manejo de propiedades de bienes raices de la compañia Millon and UP",
        Contact = new OpenApiContact
        {
            Name = "Yeiner  Merino",
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\n Example: 'Bearer 8c60e037-2722-4c50-a542-4df4f9ff1b26'",
        Name = "Bearer",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "Http",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
});

// Add Jwt
var jwtSecretKetBytes = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSetting").GetValue<string>("SecretKey"));
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(jwtSecretKetBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

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
    services.AddTransient<IAuthenicationService, AuthenicationService>();
    services.AddTransient<IPropertyImageService, PropertyImageService>();
    services.AddTransient<IOwnerService, OwnerService>();
    builder.Services.AddScoped<IValidator<PropertyRequestDto>, PropertyRequestValidator>();
}
