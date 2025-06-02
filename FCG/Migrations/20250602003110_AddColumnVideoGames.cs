using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCG.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnVideoGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountPerc",
                table: "VideoGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "VideoGames",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPerc",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "VideoGames");
        }
    }
}
