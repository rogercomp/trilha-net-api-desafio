using Microsoft.EntityFrameworkCore;
using System;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TarefaDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarefa>()
                .HasData(new Tarefa
                {
                    Id = 1,
                    Titulo = "Comprar p�o",
                    Descricao = "Ir na padaria na rua de baixo e comprar 6 p�es ",
                    Data = DateTime.Now.AddDays(2),
                    Status = EnumStatusTarefa.Pendente
                },
                         new Tarefa
                         {
                             Id = 2,
                             Titulo = "Comprar carne para churrasco",
                             Descricao = "Ir no a�ouguee comprar 3 Kgs de picanha ",
                             Data = DateTime.Now.AddDays(3),
                             Status = EnumStatusTarefa.Pendente
                         }
                         );
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}