using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendProyecto.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Series_SeriesId",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_SeriesId",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "MovieGenres");

            migrationBuilder.CreateTable(
                name: "SeriesGenre",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesGenre", x => new { x.SeriesId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_SeriesGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesGenre_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "SeriesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesGenre_GenreId",
                table: "SeriesGenre",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriesGenre");

            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "MovieGenres",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_SeriesId",
                table: "MovieGenres",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Series_SeriesId",
                table: "MovieGenres",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId");
        }
    }
}
