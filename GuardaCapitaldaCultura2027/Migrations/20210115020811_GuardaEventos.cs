﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaCapitaldaCultura2027.Migrations
{
    public partial class GuardaEventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Assunto = table.Column<string>(maxLength: 100, nullable: false),
                    Mensagem = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactoId);
                });

            migrationBuilder.CreateTable(
                name: "LugarEventos",
                columns: table => new
                {
                    LugarEventoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocupado = table.Column<bool>(nullable: false),
                    NumeroCadeira = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugarEventos", x => x.LugarEventoId);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    MunicipioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Data_imagem = table.Column<DateTime>(nullable: false),
                    Desativar = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: false),
                    Imagem = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.MunicipioId);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(nullable: false),
                    PessoaId = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 20, nullable: true),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    Numero_Reserva = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    Data_realizacao = table.Column<DateTime>(nullable: false),
                    Imagem = table.Column<byte[]>(nullable: false),
                    Lotacao_max = table.Column<int>(nullable: false),
                    Lotacao_Ocupada = table.Column<int>(nullable: false),
                    MunicipioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "MunicipioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_MunicipioId",
                table: "Eventos",
                column: "MunicipioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "LugarEventos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Municipio");
        }
    }
}
