using Azure.Storage.Blobs;
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
builder.Services.AddScoped<IAdditiveService, AdditiveService>();
builder.Services.AddSingleton<IFileService, FileService>();

builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAuthenticationConf(builder.Configuration);
builder.Services.AddAuthorizationPolicyConf();
builder.Services.AddSingleton(_ => new BlobServiceClient(builder.Configuration.GetConnectionString("DataStorage")));
// connection string "UsedevelopmentStorage=true;DevelopmentStorageProxyUri=http://127.0.0.1:10000/devstoreaccount1"

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
