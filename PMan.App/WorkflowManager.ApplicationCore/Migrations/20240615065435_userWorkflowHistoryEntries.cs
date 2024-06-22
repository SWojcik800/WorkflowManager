using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowManager.App.Migrations
{
    /// <inheritdoc />
    public partial class userWorkflowHistoryEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserWorkflowHistoryEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserWorkflowId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionUserId = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkflowHistoryEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWorkflowHistoryEntries_UserWorkflows_UserWorkflowId",
                        column: x => x.UserWorkflowId,
                        principalTable: "UserWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkflowHistoryEntries_Users_ActionUserId",
                        column: x => x.ActionUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflowHistoryEntries_ActionUserId",
                table: "UserWorkflowHistoryEntries",
                column: "ActionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflowHistoryEntries_UserWorkflowId",
                table: "UserWorkflowHistoryEntries",
                column: "UserWorkflowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWorkflowHistoryEntries");
        }
    }
}
