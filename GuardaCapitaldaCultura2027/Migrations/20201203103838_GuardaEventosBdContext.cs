using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaCapitaldaCultura2027.Migrations
{
    public partial class GuardaEventosBdContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guarda");

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Descricao = table.Column<int>(nullable: false),
                    Data_realizacao = table.Column<int>(nullable: false),
                    Lotacao_max = table.Column<int>(nullable: false),
                    Local_ocupacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventosId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.CreateTable(
                name: "Guarda",
                columns: table => new
                {
                    DataRealizacao = table.Column<DateTime>(nullable: false),
                    Descrição = table.Column<string>(maxLength: 250, nullable: true),
                    GuardaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalOcupado = table.Column<bool>(nullable: false),
                    LotacaoMaxima = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guarda_GuardaId",
                table: "Guarda",
                column: "GuardaId");
        }
    }
}
