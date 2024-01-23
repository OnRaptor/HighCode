using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionOfTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complexity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProgrammingLanguages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionOfTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionOfTasks_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserData_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CodeTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitTestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateFuncSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complexity = table.Column<int>(type: "int", nullable: false),
                    ProgrammingLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CollectionOfTasksId = table.Column<int>(type: "int", nullable: true),
                    UserDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeTasks_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CodeTasks_CollectionOfTasks_CollectionOfTasksId",
                        column: x => x.CollectionOfTasksId,
                        principalTable: "CollectionOfTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CodeTasks_UserData_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CodeTaskSolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedTaskId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VotesUp = table.Column<int>(type: "int", nullable: false),
                    VotesDown = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTaskSolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeTaskSolutions_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CodeTaskSolutions_CodeTasks_RelatedTaskId",
                        column: x => x.RelatedTaskId,
                        principalTable: "CodeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedTaskId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_CodeTaskSolutions_RelatedTaskId",
                        column: x => x.RelatedTaskId,
                        principalTable: "CodeTaskSolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeTasks_AuthorId",
                table: "CodeTasks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTasks_CollectionOfTasksId",
                table: "CodeTasks",
                column: "CollectionOfTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTasks_UserDataId",
                table: "CodeTasks",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTaskSolutions_AuthorId",
                table: "CodeTaskSolutions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTaskSolutions_RelatedTaskId",
                table: "CodeTaskSolutions",
                column: "RelatedTaskId");

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
                name: "IX_UserData_UserId",
                table: "UserData",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CodeTaskSolutions");

            migrationBuilder.DropTable(
                name: "CodeTasks");

            migrationBuilder.DropTable(
                name: "CollectionOfTasks");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
