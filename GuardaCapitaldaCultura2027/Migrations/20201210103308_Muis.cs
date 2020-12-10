using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaCapitaldaCultura2027.Migrations
{
    public partial class Muis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipios",
                table: "Municipios");

            migrationBuilder.RenameTable(
                name: "Municipios",
                newName: "Muicipios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Muicipios",
                table: "Muicipios",
                column: "MuicipioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Muicipios",
                table: "Muicipios");

            migrationBuilder.RenameTable(
                name: "Muicipios",
                newName: "Municipios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipios",
                table: "Municipios",
                column: "MuicipioId");
        }
    }
}
