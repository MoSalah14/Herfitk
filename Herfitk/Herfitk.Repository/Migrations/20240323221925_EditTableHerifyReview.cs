using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herfitk.Repository.Migrations
{
    /// <inheritdoc />
    public partial class EditTableHerifyReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Client_Herify");

            migrationBuilder.DropColumn(
                name: "Herify_Review",
                table: "Client_Herify");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Client_Herify");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Client_Herify",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Herify_Review",
                table: "Client_Herify",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Client_Herify",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
