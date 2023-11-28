using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(
            new Produto() { ProdutoId = 1, Nome = "Placa de Vídeo", Valor = 1000 },
            new Produto() { ProdutoId = 2, Nome = "Placa de Vídeo", Valor = 1500 },
            new Produto() { ProdutoId = 3, Nome = "Placa de Vídeo", Valor = 1350 },
            new Produto() { ProdutoId = 4, Nome = "Processador", Valor = 2000 },
            new Produto() { ProdutoId = 5, Nome = "Processador", Valor = 2100 },
            new Produto() { ProdutoId = 6, Nome = "Memória", Valor = 300 },
            new Produto() { ProdutoId = 7, Nome = "Memória", Valor = 350 },
            new Produto() { ProdutoId = 8, Nome = "Placa mãe", Valor = 1100 });
        }
    }
}
