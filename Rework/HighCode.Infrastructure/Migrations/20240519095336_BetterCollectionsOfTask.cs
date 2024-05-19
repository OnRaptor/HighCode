using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BetterCollectionsOfTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complexity",
                table: "CollectionOfTasks");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguages",
                table: "CollectionOfTasks");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "CollectionOfTasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "CollectionOfTasks");

            migrationBuilder.AddColumn<int>(
                name: "Complexity",
                table: "CollectionOfTasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProgrammingLanguages",
                table: "CollectionOfTasks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
