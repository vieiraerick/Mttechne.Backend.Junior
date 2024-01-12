using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mttechne.Backend.Junior.Repository.Migrations
{
    public partial class CriacaoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[,]
                {
                    { 1, "Placa de Vídeo", 1000 },
                    { 2, "Placa de Vídeo", 1500 },
                    { 3, "Placa de Vídeo", 1350 },
                    { 4, "Processador", 2000 },
                    { 5, "Processador", 2100 },
                    { 6, "Memória", 300 },
                    { 7, "Memória", 350 },
                    { 8, "Placa mãe", 1100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
