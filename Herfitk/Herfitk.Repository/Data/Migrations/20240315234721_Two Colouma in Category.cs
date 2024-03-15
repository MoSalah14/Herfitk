using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herfitk.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class TwoColoumainCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Category",
                newName: "CategoryName");

            migrationBuilder.AddColumn<string>(
                name: "Descraption",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descraption",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "Type");
        }
    }
}
