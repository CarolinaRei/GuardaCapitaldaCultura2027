using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaCapitaldaCultura2027.Migrations
{
    public partial class Municipio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Municipios_MunicipioId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipios",
                table: "Municipios");

            migrationBuilder.RenameTable(
                name: "Municipios",
                newName: "Municipio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipio",
                table: "Municipio",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Municipio_MunicipioId",
                table: "Eventos",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Municipio_MunicipioId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipio",
                table: "Municipio");

            migrationBuilder.RenameTable(
                name: "Municipio",
                newName: "Municipios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipios",
                table: "Municipios",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Municipios_MunicipioId",
                table: "Eventos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
