using Notification.API.Helpers.Extentions;
using Notification.API.Infastructure.Implementations;
using Notification.API.Infastructure.Interfaces;
using Notification.API.Services.Implementations;
using Notification.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddScoped<IEmailProvider, EmailProvider>();

builder.Services.AddMassTransit(builder.Configuration);
builder.Host.SerilogConfigure();

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
