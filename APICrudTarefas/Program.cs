using APICrudTarefas.Application.Interfaces;
using APICrudTarefas.Infrastructure.Data;
using APICrudTarefas.Application.DTO.Validations;
using APICrudTarefas.Application.Service;
using APICrudTarefas.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using APICrudTarefas.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CriarTarefaValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AtualizarTarefaValidator>();

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

builder.Services.AddScoped<TarefaService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
