using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roblocks.Migrations
{
    /// <inheritdoc />
    public partial class example : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "likes",
                table: "Games",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "leaderBoard",
                table: "Games",
                newName: "LeaderBoard");

            migrationBuilder.RenameColumn(
                name: "dislikes",
                table: "Games",
                newName: "Dislikes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Games",
                newName: "likes");

            migrationBuilder.RenameColumn(
                name: "LeaderBoard",
                table: "Games",
                newName: "leaderBoard");

            migrationBuilder.RenameColumn(
                name: "Dislikes",
                table: "Games",
                newName: "dislikes");
        }
    }
}
