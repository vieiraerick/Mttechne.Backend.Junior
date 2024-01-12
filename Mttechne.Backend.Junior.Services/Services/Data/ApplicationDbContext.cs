using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Services.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        private static DbContextOptions<ApplicationDbContext> GetDefaultDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // Adicione quaisquer configurações padrão que você deseje aqui
            return builder.Options;
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(e =>
            {
                e.HasKey(u => u.Id);
            });
        }
    }
}
