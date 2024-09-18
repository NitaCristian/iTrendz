using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTrendz.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Comments",
                table: "Campaigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Engagement",
                table: "Campaigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Campaigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reach",
                table: "Campaigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Shares",
                table: "Campaigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Campaigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Engagement",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Reach",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Shares",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Campaigns");
        }
    }
}
