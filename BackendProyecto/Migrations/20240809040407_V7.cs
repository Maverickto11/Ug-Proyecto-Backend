using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendProyecto.Migrations
{
    /// <inheritdoc />
    public partial class V7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "MovieGenres",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Overview = table.Column<string>(type: "text", nullable: false),
                    PosterPath = table.Column<string>(type: "text", nullable: false),
                    BackdropPath = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<decimal>(type: "numeric", nullable: true),
                    VoteCount = table.Column<int>(type: "integer", nullable: true),
                    NumberOfSeasons = table.Column<int>(type: "integer", nullable: true),
                    NumberOfEpisodes = table.Column<int>(type: "integer", nullable: true),
                    Trailer = table.Column<string>(type: "text", nullable: true),
                    Tipo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SeriesId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Series_SeriesId",
                table: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_SeriesId",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "MovieGenres");
        }
    }
}
