using Isteyap.Core.Application;
using Isteyap.Infrastructure.Infrastructure;
using Isteyap.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.AddInfrastructureApplicationBuilderRegistration();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationServiceRegistration(builder.Configuration);
builder.Services.AddInfrastructurePersistenceServiceRegistration(builder.Configuration);
builder.Services.AddInfrastructureServiceRegistration(builder.Configuration);

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
