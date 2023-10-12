using Jazani.Application.Admins.Dtos.Personas.Mappers;
using Jazani.Application.Admins.Services;
using Jazani.Application.Admins.Services.Implementations;

using Autofac.Extensions.DependencyInjection;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Application.Cores.Contexts;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructures
builder.Services.addInfrastructureServices(builder.Configuration);

// Applications
builder.Services.AddApplicationServices();

// autofact
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfrastructureAutofactModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });

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
