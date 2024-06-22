using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowManager.App.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValueInDictionary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowStage_Workflows_WorkflowId",
                table: "WorkflowStage");

            migrationBuilder.DropTable(
                name: "StorageItems");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowId",
                table: "WorkflowStage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowId",
                table: "WorkflowFields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "DictionaryItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowStage_Workflows_WorkflowId",
                table: "WorkflowStage",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowStage_Workflows_WorkflowId",
                table: "WorkflowStage");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "DictionaryItems");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowId",
                table: "WorkflowStage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowId",
                table: "WorkflowFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StorageItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(520)", maxLength: 520, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StorageI__3214EC076EED088E", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowStage_Workflows_WorkflowId",
                table: "WorkflowStage",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
