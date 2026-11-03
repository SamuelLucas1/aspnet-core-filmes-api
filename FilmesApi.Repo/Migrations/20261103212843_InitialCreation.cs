using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmesApi.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diretores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, 1, "Jurassic Park", 1993 },
                    { 2, 1, "Jaws", 1975 },
                    { 3, 1, "E.T. the Extra-Terrestrial", 1982 },
                    { 4, 1, "Schindler's List", 1993 },
                    { 5, 2, "Inception", 2010 },
                    { 6, 2, "The Dark Knight", 2008 },
                    { 7, 2, "Interstellar", 2014 },
                    { 8, 3, "Pulp Fiction", 1994 },
                    { 9, 3, "Kill Bill: Vol. 1", 2003 },
                    { 10, 3, "Django Unchained", 2012 },
                    { 11, 4, "Goodfellas", 1990 },
                    { 12, 4, "Taxi Driver", 1976 },
                    { 13, 4, "The Departed", 2006 },
                    { 14, 5, "Titanic", 1997 },
                    { 15, 5, "Avatar", 2009 },
                    { 16, 5, "Terminator 2: Judgment Day", 1991 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes",
                column: "DiretorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Diretores");
        }
    }
}
