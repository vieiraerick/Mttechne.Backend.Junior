using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Data.Mappings;
using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Data.Context
{
    public partial class MttechneDbContext : DbContext
    {
        public MttechneDbContext(DbContextOptions<MttechneDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
        }

        public virtual DbSet<Produto> Produto { get; set; }
    }
}
