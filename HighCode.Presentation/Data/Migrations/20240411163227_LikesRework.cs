using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class LikesRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "VotesDown",
                table: "CodeTaskSolutions");

            migrationBuilder.DropColumn(
                name: "VotesUp",
                table: "CodeTaskSolutions");

            migrationBuilder.AlterColumn<string>(
                name: "AnotherAuthor",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CodeTaskSolutionReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Reaction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTaskSolutionReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeTaskSolutionReactions_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CodeTaskSolutionReactions_CodeTaskSolutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "CodeTaskSolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Reaction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentsReactions_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentsReactions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeTaskSolutionReactions_AuthorId",
                table: "CodeTaskSolutionReactions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTaskSolutionReactions_SolutionId",
                table: "CodeTaskSolutionReactions",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsReactions_AuthorId",
                table: "CommentsReactions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsReactions_CommentId",
                table: "CommentsReactions",
                column: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeTaskSolutionReactions");

            migrationBuilder.DropTable(
                name: "CommentsReactions");

            migrationBuilder.AlterColumn<string>(
                name: "AnotherAuthor",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VotesDown",
                table: "CodeTaskSolutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VotesUp",
                table: "CodeTaskSolutions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
