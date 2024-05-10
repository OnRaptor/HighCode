using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewCommentsTargetIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_Comments_RelatedTaskId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RelatedTaskId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "RepliedCommentId",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "RelatedTaskSolutionId",
                table: "Comments",
                newName: "CodeTaskSolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_RepliedCommentId",
                table: "Comments",
                newName: "IX_Comments_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_RelatedTaskSolutionId",
                table: "Comments",
                newName: "IX_Comments_CodeTaskSolutionId");

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedTargetId",
                table: "Comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TargetType",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CodeTaskSolutions_CodeTaskSolutionId",
                table: "Comments",
                column: "CodeTaskSolutionId",
                principalTable: "CodeTaskSolutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CodeTaskSolutions_CodeTaskSolutionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RelatedTargetId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TargetType",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "RepliedCommentId");

            migrationBuilder.RenameColumn(
                name: "CodeTaskSolutionId",
                table: "Comments",
                newName: "RelatedTaskSolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                newName: "IX_Comments_RepliedCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CodeTaskSolutionId",
                table: "Comments",
                newName: "IX_Comments_RelatedTaskSolutionId");

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedTaskId",
                table: "Comments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RelatedTaskId",
                table: "Comments",
                column: "RelatedTaskId");

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
    }
}
