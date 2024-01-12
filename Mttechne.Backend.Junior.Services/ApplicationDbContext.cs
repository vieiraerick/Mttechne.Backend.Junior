using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer("Server=DESKTOP-G3U23SP;Database=Produtos;Integrated Security=True;Encrypt=YES;TrustServerCertificate=YES");
    }
}
