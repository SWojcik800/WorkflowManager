using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowManager.App.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CraetedById",
                table: "Attachments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CraetedById",
                table: "Attachments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
