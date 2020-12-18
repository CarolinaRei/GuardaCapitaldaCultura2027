using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaCapitaldaCultura2027.Migrations
{
    public partial class Turistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Turista",
                table: "Turista");

            migrationBuilder.RenameTable(
                name: "Turista",
                newName: "Turistas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turistas",
                table: "Turistas",
                column: "TuristaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Turistas",
                table: "Turistas");

            migrationBuilder.RenameTable(
                name: "Turistas",
                newName: "Turista");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turista",
                table: "Turista",
                column: "TuristaId");
        }
    }
}
