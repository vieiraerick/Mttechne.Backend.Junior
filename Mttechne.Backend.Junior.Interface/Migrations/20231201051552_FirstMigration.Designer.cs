﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mttechne.Backend.Junior.Services.Data.Context;

#nullable disable

namespace Mttechne.Backend.Junior.Interface.Migrations
{
    [DbContext(typeof(MttechneDbContext))]
    [Migration("20231201051552_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Mttechne.Backend.Junior.Services.Model.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<int>("Valor")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
