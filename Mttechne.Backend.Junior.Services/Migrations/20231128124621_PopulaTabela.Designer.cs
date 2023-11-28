﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mttechne.Backend.Junior.Services.Context;

#nullable disable

namespace Mttechne.Backend.Junior.Services.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231128124621_PopulaTabela")]
    partial class PopulaTabela
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Mttechne.Backend.Junior.Services.Model.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            Nome = "Placa de Vídeo",
                            Valor = 1000
                        },
                        new
                        {
                            ProdutoId = 2,
                            Nome = "Placa de Vídeo",
                            Valor = 1500
                        },
                        new
                        {
                            ProdutoId = 3,
                            Nome = "Placa de Vídeo",
                            Valor = 1350
                        },
                        new
                        {
                            ProdutoId = 4,
                            Nome = "Processador",
                            Valor = 2000
                        },
                        new
                        {
                            ProdutoId = 5,
                            Nome = "Processador",
                            Valor = 2100
                        },
                        new
                        {
                            ProdutoId = 6,
                            Nome = "Memória",
                            Valor = 300
                        },
                        new
                        {
                            ProdutoId = 7,
                            Nome = "Memória",
                            Valor = 350
                        },
                        new
                        {
                            ProdutoId = 8,
                            Nome = "Placa mãe",
                            Valor = 1100
                        });
                });
#pragma warning restore 612, 618
        }
    }
}