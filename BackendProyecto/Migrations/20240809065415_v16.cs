using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendProyecto.Migrations
{
    /// <inheritdoc />
    public partial class v16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenre_Genres_GenreId",
                table: "SeriesGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenre_Series_SeriesId",
                table: "SeriesGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesGenre",
                table: "SeriesGenre");

            migrationBuilder.RenameTable(
                name: "SeriesGenre",
                newName: "SeriesGenres");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesGenre_GenreId",
                table: "SeriesGenres",
                newName: "IX_SeriesGenres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesGenres",
                table: "SeriesGenres",
                columns: new[] { "SeriesId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenres_Genres_GenreId",
                table: "SeriesGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenres_Series_SeriesId",
                table: "SeriesGenres",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenres_Genres_GenreId",
                table: "SeriesGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenres_Series_SeriesId",
                table: "SeriesGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesGenres",
                table: "SeriesGenres");

            migrationBuilder.RenameTable(
                name: "SeriesGenres",
                newName: "SeriesGenre");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesGenres_GenreId",
                table: "SeriesGenre",
                newName: "IX_SeriesGenre_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesGenre",
                table: "SeriesGenre",
                columns: new[] { "SeriesId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenre_Genres_GenreId",
                table: "SeriesGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenre_Series_SeriesId",
                table: "SeriesGenre",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
