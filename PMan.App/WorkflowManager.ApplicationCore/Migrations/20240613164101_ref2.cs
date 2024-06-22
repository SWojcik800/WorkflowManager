using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowManager.App.Migrations
{
    /// <inheritdoc />
    public partial class ref2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStageFields_WorkflowStageId",
                table: "WorkflowStageFields",
                column: "WorkflowStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowStageFields_WorkflowStage_WorkflowStageId",
                table: "WorkflowStageFields",
                column: "WorkflowStageId",
                principalTable: "WorkflowStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowStageFields_WorkflowStage_WorkflowStageId",
                table: "WorkflowStageFields");

            migrationBuilder.DropIndex(
                name: "IX_WorkflowStageFields_WorkflowStageId",
                table: "WorkflowStageFields");
        }
    }
}
