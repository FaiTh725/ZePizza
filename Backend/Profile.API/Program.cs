using Profile.API.Dal;
using Profile.API.Dal.Implementations;
using Profile.API.Helpers.Extentions;
using Profile.API.Services.Implementations;
using Profile.Domain.Abstractions.Repositories;
using Profile.Domain.Abstractions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddMassTransit(builder.Configuration);
builder.Services.AddHttpClients(builder.Configuration);
builder.Host.AddSerilog();

builder.Services.AddDbContext<AppDbContext>();

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
