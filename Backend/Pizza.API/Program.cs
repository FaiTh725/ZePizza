using Pizza.API.Dal;
using Pizza.API.Dal.Implementations;
using Pizza.API.Dal.Interfaces;
using Pizza.API.Helpers.Extentions;
using Pizza.API.Services.Implementations;
using Pizza.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPizzaService, PizzaService>();

builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAuthenticationConf(builder.Configuration);
builder.Services.AddAuthorizationPolicyConf();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
