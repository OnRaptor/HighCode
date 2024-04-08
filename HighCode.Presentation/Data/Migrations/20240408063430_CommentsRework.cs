using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommentsRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CodeTaskSolutions_RelatedTaskId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "RelatedTaskId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RelatedTaskSolutionId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepliedCommentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RelatedTaskSolutionId",
                table: "Comments",
                column: "RelatedTaskSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RepliedCommentId",
                table: "Comments",
                column: "RepliedCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CodeTaskSolutions_RelatedTaskSolutionId",
                table: "Comments",
                column: "RelatedTaskSolutionId",
                principalTable: "CodeTaskSolutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CodeTasks_RelatedTaskId",
                table: "Comments",
                column: "RelatedTaskId",
                principalTable: "CodeTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_RepliedCommentId",
                table: "Comments",
                column: "RepliedCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CodeTaskSolutions_RelatedTaskSolutionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CodeTasks_RelatedTaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_RepliedCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RelatedTaskSolutionId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RepliedCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RelatedTaskSolutionId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RepliedCommentId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "RelatedTaskId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CodeTaskSolutions_RelatedTaskId",
                table: "Comments",
                column: "RelatedTaskId",
                principalTable: "CodeTaskSolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
