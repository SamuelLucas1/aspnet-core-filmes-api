using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaAnoAosFilmes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: 1993);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: 1975);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: 1982);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Year",
                value: 1993);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: 2010);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: 2008);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: 2014);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Year",
                value: 1994);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Year",
                value: 2003);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Year",
                value: 2012);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Year",
                value: 1990);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Year",
                value: 1976);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Year",
                value: 2006);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Year",
                value: 1997);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Year",
                value: 2009);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 16,
                column: "Year",
                value: 1991);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 16,
                column: "Year",
                value: 0);
        }
    }
}
