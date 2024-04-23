using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionOfTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Complexity = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgrammingLanguages = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionOfTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionOfTasks_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaderboard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaderboard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaderboard_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodeTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UnitTestCode = table.Column<string>(type: "text", nullable: false),
                    TemplateFuncSignature = table.Column<string>(type: "text", nullable: false),
                    Complexity = table.Column<int>(type: "integer", nullable: false),
                    ProgrammingLanguage = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true),
                    CollectionOfTasksId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeTasks_CollectionOfTasks_CollectionOfTasksId",
                        column: x => x.CollectionOfTasksId,
                        principalTable: "CollectionOfTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CodeTasks_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CodeTaskSolutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedTaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsTested = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTaskSolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeTaskSolutions_CodeTasks_RelatedTaskId",
                        column: x => x.RelatedTaskId,
                        principalTable: "CodeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CodeTaskSolutions_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodeTaskSolutionReactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SolutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reaction = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTaskSolutionReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeTaskSolutionReactions_CodeTaskSolutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "CodeTaskSolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CodeTaskSolutionReactions_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedTaskSolutionId = table.Column<Guid>(type: "uuid", nullable: true),
                    RelatedTaskId = table.Column<Guid>(type: "uuid", nullable: true),
                    RepliedCommentId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AnotherAuthor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_CodeTaskSolutions_RelatedTaskSolutionId",
                        column: x => x.RelatedTaskSolutionId,
                        principalTable: "CodeTaskSolutions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_CodeTasks_RelatedTaskId",
                        column: x => x.RelatedTaskId,
                        principalTable: "CodeTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Comments_RepliedCommentId",
                        column: x => x.RepliedCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsReactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reaction = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentsReactions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentsReactions_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
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
                name: "IX_CodeTaskSolutions_AuthorId",
                table: "CodeTaskSolutions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTaskSolutions_RelatedTaskId",
                table: "CodeTaskSolutions",
                column: "RelatedTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTasks_AuthorId",
                table: "CodeTasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTasks_CollectionOfTasksId",
                table: "CodeTasks",
                column: "CollectionOfTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionOfTasks_AuthorId",
                table: "CollectionOfTasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RelatedTaskId",
                table: "Comments",
                column: "RelatedTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RelatedTaskSolutionId",
                table: "Comments",
                column: "RelatedTaskSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RepliedCommentId",
                table: "Comments",
                column: "RepliedCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsReactions_AuthorId",
                table: "CommentsReactions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsReactions_CommentId",
                table: "CommentsReactions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboard_UserId",
                table: "Leaderboard",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeTaskSolutionReactions");

            migrationBuilder.DropTable(
                name: "CommentsReactions");

            migrationBuilder.DropTable(
                name: "Leaderboard");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CodeTaskSolutions");

            migrationBuilder.DropTable(
                name: "CodeTasks");

            migrationBuilder.DropTable(
                name: "CollectionOfTasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
