using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaCapitaldaCultura2027.Migrations
{
    public partial class Ver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Muicipios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventosId",
                table: "Muicipios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muicipios_EventosId",
                table: "Muicipios",
                column: "EventosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Muicipios_Evento_EventosId",
                table: "Muicipios",
                column: "EventosId",
                principalTable: "Evento",
                principalColumn: "EventosId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Muicipios_Evento_EventosId",
                table: "Muicipios");

            migrationBuilder.DropIndex(
                name: "IX_Muicipios_EventosId",
                table: "Muicipios");

            migrationBuilder.DropColumn(
                name: "EventosId",
                table: "Muicipios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Muicipios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
