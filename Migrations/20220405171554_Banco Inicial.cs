using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteliHealth.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topico",
                columns: table => new
                {
                    IdTopico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topico", x => x.IdTopico);
                });

            migrationBuilder.CreateTable(
                name: "Lembrete",
                columns: table => new
                {
                    IdLembrete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTopico = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lembrete", x => x.IdLembrete);
                    table.ForeignKey(
                        name: "FK_Lembrete_Topico_IdTopico",
                        column: x => x.IdTopico,
                        principalTable: "Topico",
                        principalColumn: "IdTopico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    IdResposta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTopico = table.Column<int>(type: "int", nullable: false),
                    Realizado = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.IdResposta);
                    table.ForeignKey(
                        name: "FK_Resposta_Topico_IdTopico",
                        column: x => x.IdTopico,
                        principalTable: "Topico",
                        principalColumn: "IdTopico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lembrete_IdTopico",
                table: "Lembrete",
                column: "IdTopico");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_IdTopico",
                table: "Resposta",
                column: "IdTopico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lembrete");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Topico");
        }
    }
}
