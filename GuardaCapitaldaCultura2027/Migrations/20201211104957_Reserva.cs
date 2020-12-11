using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaCapitaldaCultura2027.Migrations
{
    public partial class Reserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Turista",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Evento",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_Reserva = table.Column<string>(nullable: true),
                    FeedBack = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turista_ReservaId",
                table: "Turista",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_ReservaId",
                table: "Evento",
                column: "ReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Reserva_ReservaId",
                table: "Evento",
                column: "ReservaId",
                principalTable: "Reserva",
                principalColumn: "ReservaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turista_Reserva_ReservaId",
                table: "Turista",
                column: "ReservaId",
                principalTable: "Reserva",
                principalColumn: "ReservaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Reserva_ReservaId",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Turista_Reserva_ReservaId",
                table: "Turista");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Turista_ReservaId",
                table: "Turista");

            migrationBuilder.DropIndex(
                name: "IX_Evento_ReservaId",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Turista");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Evento");
        }
    }
}
