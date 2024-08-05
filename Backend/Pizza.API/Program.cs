using Azure.Storage.Blobs;
using Pizza.API.Dal;
using Pizza.API.Dal.Implementations;
using Pizza.API.Dal.Interfaces;
using Pizza.API.Helpers.Extentions;
using Pizza.API.Services.Implementations;
using Pizza.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IAdditiveService, AdditiveService>();
builder.Services.AddSingleton<IFileService, FileService>();

builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<IAdditiveRepository, AdditiveRepository>();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAuthenticationConf(builder.Configuration);
builder.Services.AddAuthorizationPolicyConf();
builder.Services.AddSingleton(_ => new BlobServiceClient(builder.Configuration.GetConnectionString("DataStorage")));

var app = builder.Build();

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
