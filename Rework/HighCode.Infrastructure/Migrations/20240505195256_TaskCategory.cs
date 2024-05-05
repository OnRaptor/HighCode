using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TaskCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "CodeTasks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "CodeTasks");
        }
    }
}
