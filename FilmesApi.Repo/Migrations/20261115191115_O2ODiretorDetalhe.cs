using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmesApi.Repo.Migrations
{
    /// <inheritdoc />
    public partial class O2ODiretorDetalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiretoresDetalhes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Biografia = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretoresDetalhes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiretoresDetalhes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiretoresDetalhes",
                columns: new[] { "Id", "Biografia", "DataNascimento", "DiretorId" },
                values: new object[,]
                {
                    { 1, "Steven Spielberg é um renomado diretor de cinema americano, conhecido por seus filmes icônicos e inovadores.", new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Christopher Nolan é um diretor britânico-americano, famoso por seus filmes complexos e visualmente impressionantes.", new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiretoresDetalhes_DiretorId",
                table: "DiretoresDetalhes",
                column: "DiretorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiretoresDetalhes");
        }
    }
}
