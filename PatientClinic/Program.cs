using System.Text.Json.Serialization;
using Application.Commands.PatientCommand;
using Application.DTO;
using Application.IRepositories;
using Domain;
using infrastructure;
using Infrastructure;
using MediatR;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddMediatR(typeof(CreatePatientCommand).Assembly);
builder.Services.AddControllers()
    .AddJsonOptions(o =>
       o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
