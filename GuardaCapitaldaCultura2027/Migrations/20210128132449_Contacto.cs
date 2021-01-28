using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaCapitaldaCultura2027.Migrations
{
    public partial class Contacto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Reservas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resposta",
                table: "Contactos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verificado",
                table: "Contactos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EventoId",
                table: "Reservas",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Eventos_EventoId",
                table: "Reservas",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Eventos_EventoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_EventoId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Resposta",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "Verificado",
                table: "Contactos");
        }
    }
}
