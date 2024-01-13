
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produtos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Produto>().HasData(
                new Produto() { ID=1, Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { ID=2, Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { ID=3, Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto() { ID=4, Nome = "Processador", Valor = 2000 },
                new Produto() { ID=5, Nome = "Processador", Valor = 2100 },
                new Produto() { ID=6, Nome = "Memória", Valor = 300 },
                new Produto() { ID=7, Nome = "Memória", Valor = 350 },
                new Produto() { ID=8, Nome = "Placa mãe", Valor = 1100 }
            );
        }
    }
}