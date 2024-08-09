using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendProyecto.Migrations
{
    /// <inheritdoc />
    public partial class V8 : Migration
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

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Series_MovieId",
                table: "MovieGenres",
                column: "MovieId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Series_MovieId",
                table: "MovieGenres");

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
