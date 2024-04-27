using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstPublishDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FirstPublishDate",
                table: "CodeTaskSolutions",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstPublishDate",
                table: "CodeTaskSolutions");
        }
    }
}
