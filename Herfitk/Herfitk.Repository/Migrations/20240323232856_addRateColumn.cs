using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herfitk.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addRateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Client_Herify",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Client_Herify");
        }
    }
}