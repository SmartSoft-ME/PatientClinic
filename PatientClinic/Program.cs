using System.Text.Json.Serialization;
using Application.Commands.PatientCommand;
using Application.DTO;
using Application.IRepositories;
using Domain;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(o =>
       o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddInfrastructure();
builder.Services.AddTransient<IInjuryRepository, InjuryRepository>();
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreatePatientCommand).Assembly);
});
var app = builder.Build();
// Configure the HTTP request pipeline.

builder.Services.AddCors();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));

app.UseHttpsRedirection();

app.UseInfrastructure();


app.UseAuthorization();

app.MapControllers();

app.Run();
