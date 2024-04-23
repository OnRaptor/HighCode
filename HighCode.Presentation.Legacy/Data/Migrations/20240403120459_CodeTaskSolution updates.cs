using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class CodeTaskSolutionupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodeTaskSolutions_AspNetUsers_AuthorId",
                table: "CodeTaskSolutions");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "CodeTaskSolutions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "CodeTaskSolutions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTested",
                table: "CodeTaskSolutions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_CodeTaskSolutions_AspNetUsers_AuthorId",
                table: "CodeTaskSolutions",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodeTaskSolutions_AspNetUsers_AuthorId",
                table: "CodeTaskSolutions");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "CodeTaskSolutions");

            migrationBuilder.DropColumn(
                name: "IsTested",
                table: "CodeTaskSolutions");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "CodeTaskSolutions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_CodeTaskSolutions_AspNetUsers_AuthorId",
                table: "CodeTaskSolutions",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
