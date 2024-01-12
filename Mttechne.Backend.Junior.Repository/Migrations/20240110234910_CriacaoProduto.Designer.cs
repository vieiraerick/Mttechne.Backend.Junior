﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mttechne.Backend.Junior.Repository.Context;

#nullable disable

namespace Mttechne.Backend.Junior.Repository.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240110234910_CriacaoProduto")]
    partial class CriacaoProduto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Mttechne.Backend.Junior.Domain.Model.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Placa de Vídeo",
                            Valor = 1000
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Placa de Vídeo",
                            Valor = 1500
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Placa de Vídeo",
                            Valor = 1350
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Processador",
                            Valor = 2000
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Processador",
                            Valor = 2100
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Memória",
                            Valor = 300
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Memória",
                            Valor = 350
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Placa mãe",
                            Valor = 1100
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
