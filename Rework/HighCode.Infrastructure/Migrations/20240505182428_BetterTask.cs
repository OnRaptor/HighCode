using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BetterTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "CodeTasks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "CodeTasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "CodeTasks");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "CodeTasks");
        }
    }
}
