using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighCode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodeTasks_CollectionOfTasks_CollectionOfTasksId",
                table: "CodeTasks");

            migrationBuilder.DropIndex(
                name: "IX_CodeTasks_CollectionOfTasksId",
                table: "CodeTasks");

            migrationBuilder.DropColumn(
                name: "CollectionOfTasksId",
                table: "CodeTasks");

            migrationBuilder.AddColumn<bool>(
                name: "IsSuggested",
                table: "CodeTasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CodeTaskCollectionOfTasks",
                columns: table => new
                {
                    CollectionsOfTasksId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTaskCollectionOfTasks", x => new { x.CollectionsOfTasksId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_CodeTaskCollectionOfTasks_CodeTasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "CodeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CodeTaskCollectionOfTasks_CollectionOfTasks_CollectionsOfTa~",
                        column: x => x.CollectionsOfTasksId,
                        principalTable: "CollectionOfTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeTaskCollectionOfTasks_TasksId",
                table: "CodeTaskCollectionOfTasks",
                column: "TasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeTaskCollectionOfTasks");

            migrationBuilder.DropColumn(
                name: "IsSuggested",
                table: "CodeTasks");

            migrationBuilder.AddColumn<Guid>(
                name: "CollectionOfTasksId",
                table: "CodeTasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CodeTasks_CollectionOfTasksId",
                table: "CodeTasks",
                column: "CollectionOfTasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodeTasks_CollectionOfTasks_CollectionOfTasksId",
                table: "CodeTasks",
                column: "CollectionOfTasksId",
                principalTable: "CollectionOfTasks",
                principalColumn: "Id");
        }
    }
}
