using Domain.RepositoryInterfaces;
using Infrastructure.DbMapping;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
//{
//    Name = "JWT Authentication",
//    Type = SecuritySchemeType.Http,
//    Scheme = JwtBearerDefaults.AuthenticationScheme,
//    BearerFormat = "JWT",
//    In = ParameterLocation.Header,
//    Reference = new OpenApiReference
//    {
//        Type = ReferenceType.SecurityScheme,
//        Id = JwtBearerDefaults.AuthenticationScheme
//    }
//};

builder.Services.AddSwaggerGen(config =>
{
    //config.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

    //config.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    { securityScheme, Array.Empty<string>() }
    //});
});

// Repositories registration
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// DbContext registration
builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Supabase"));
});

// Authentication
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
//    {
//        config.Authority = builder.Configuration["Auth0:Domain"];
//        config.Audience = builder.Configuration["Auth0:Audience"];
//    });

// Authorization
//builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();