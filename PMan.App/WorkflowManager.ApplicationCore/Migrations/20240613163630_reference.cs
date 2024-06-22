using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowManager.App.Migrations
{
    /// <inheritdoc />
    public partial class reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflows_CurrentStageId",
                table: "UserWorkflows",
                column: "CurrentStageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflows_WorkflowId",
                table: "UserWorkflows",
                column: "WorkflowId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkflows_WorkflowStage_CurrentStageId",
                table: "UserWorkflows",
                column: "CurrentStageId",
                principalTable: "WorkflowStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkflows_Workflows_WorkflowId",
                table: "UserWorkflows",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkflows_WorkflowStage_CurrentStageId",
                table: "UserWorkflows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkflows_Workflows_WorkflowId",
                table: "UserWorkflows");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkflows_CurrentStageId",
                table: "UserWorkflows");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkflows_WorkflowId",
                table: "UserWorkflows");
        }
    }
}
