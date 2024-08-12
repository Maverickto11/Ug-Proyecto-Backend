using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendProyecto.Migrations
{
    /// <inheritdoc />
    public partial class v20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackdropPath",
                table: "Favorites",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "Favorites",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackdropPath",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Overview",
                table: "Favorites");
        }
    }
}
