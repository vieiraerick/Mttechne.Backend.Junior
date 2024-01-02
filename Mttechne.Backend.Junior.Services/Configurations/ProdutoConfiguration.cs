using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
            .HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Valor).HasColumnType("Int").IsRequired();
        }
    }
}
