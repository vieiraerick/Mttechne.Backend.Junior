using Microsoft.EntityFrameworkCore.Migrations;
using Mttechne.Backend.Junior.Services.Model;
using System.Collections.Generic;

#nullable disable

namespace Mttechne.Backend.Junior.Services.Migrations
{
    public partial class PopulaBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql ("insert into Produto values('Placa de Vídeo', 1000)");
            migrationBuilder.Sql("insert into Produto values('Placa de Vídeo', 1500)");
            migrationBuilder.Sql("insert into Produto values('Placa de Vídeo', 1350)");
            migrationBuilder.Sql("insert into Produto values('Processador', 2000)");
            migrationBuilder.Sql("insert into Produto values('Processador', 2100)");
            migrationBuilder.Sql("insert into Produto values('Memória', 300)");
            migrationBuilder.Sql("insert into Produto values('Memória', 350)");
            migrationBuilder.Sql("insert into Produto values('Placa mãe', 1100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
