using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<OrganizadorContext>(options =>
//  options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddDbContext<OrganizadorContext>(options => options.UseInMemoryDatabase(databaseName: "TarefaDb"));

//builder.Services.AddTransient<DataSeeder>();

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AddSeedData(app);

void AddSeedData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<OrganizadorContext>();

    var tarefas = new Tarefa[]
                   {
                        new Tarefa {
                            Id = 1,
                            Titulo = "Comprar pão",
                            Descricao = "Ir na padaria na rua de baixo e comprar 6 pães ",
                            Data = DateTime.Now.AddDays(2),
                            Status = EnumStatusTarefa.Pendente
                        },
                         new Tarefa {
                            Id = 2,
                            Titulo = "Comprar carne para churrasco",
                            Descricao = "Ir no açouguee comprar 3 Kgs de picanha ",
                            Data = DateTime.Now.AddDays(3),
                            Status = EnumStatusTarefa.Pendente
                        }
                   };

    db.Tarefas.AddRange(tarefas);
    db.SaveChanges();
}

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
