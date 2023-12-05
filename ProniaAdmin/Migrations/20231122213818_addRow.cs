using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaAdmin.Migrations
{
    /// <inheritdoc />
    public partial class addRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "sliders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "sliders");
        }
    }
}
