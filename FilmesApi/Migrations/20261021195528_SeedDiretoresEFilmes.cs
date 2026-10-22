using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDiretoresEFilmes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Steven Spielberg" },
                    { 2, "Christopher Nolan" },
                    { 3, "Quentin Tarantino" },
                    { 4, "Martin Scorsese" },
                    { 5, "James Cameron" }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "DiretorId", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Jurassic Park", 0 },
                    { 2, 1, "Jaws", 0 },
                    { 3, 1, "E.T. the Extra-Terrestrial", 0 },
                    { 4, 1, "Schindler's List", 0 },
                    { 5, 2, "Inception", 0 },
                    { 6, 2, "The Dark Knight", 0 },
                    { 7, 2, "Interstellar", 0 },
                    { 8, 3, "Pulp Fiction", 0 },
                    { 9, 3, "Kill Bill: Vol. 1", 0 },
                    { 10, 3, "Django Unchained", 0 },
                    { 11, 4, "Goodfellas", 0 },
                    { 12, 4, "Taxi Driver", 0 },
                    { 13, 4, "The Departed", 0 },
                    { 14, 5, "Titanic", 0 },
                    { 15, 5, "Avatar", 0 },
                    { 16, 5, "Terminator 2: Judgment Day", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
