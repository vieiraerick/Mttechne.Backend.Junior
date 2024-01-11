using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Mttechne.Backend.Junior.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mttechne.Backend.Junior.Repository.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().HasData(
        new Produto() { Id = 1, Nome = "Placa de Vídeo", Valor = 1000 },
            new Produto() { Id = 2, Nome = "Placa de Vídeo", Valor = 1500 },
            new Produto() { Id = 3, Nome = "Placa de Vídeo", Valor = 1350 },
            new Produto() { Id = 4, Nome = "Processador", Valor = 2000 },
            new Produto() { Id = 5, Nome = "Processador", Valor = 2100 },
            new Produto() { Id = 6, Nome = "Memória", Valor = 300 },
            new Produto() { Id = 7, Nome = "Memória", Valor = 350 },
            new Produto() { Id = 8, Nome = "Placa mãe", Valor = 1100 }

        );
    }



    public DbSet<Produto> Produtos { get; set; }
}
