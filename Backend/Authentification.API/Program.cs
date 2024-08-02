using Authentification.API.Dal;
using Authentification.API.Dal.Impelentations;
using Authentification.API.Helpers.Extentions;
using Authentification.API.Infastructure.Implementations;
using Authentification.API.Infastructure.Interfaces;
using Authentification.API.Services.Implementations;
using Authentification.Domain.Abstractions.Repositories;
using Authentification.Domain.Abstractions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IPasswordHashind, PasswordHashind>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IRedisProvider, RedisDatabaseProvider>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, Userrepository>();

/*builder.Services.AddApiAuthentication(builder.Configuration);*/
builder.Services.AddRedis(builder.Configuration);
builder.Services.AddMassTransit(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseHttpsRedirection();
app.UseAuthentication();*/

app.UseAuthorization();

app.MapControllers();

app.Run();
