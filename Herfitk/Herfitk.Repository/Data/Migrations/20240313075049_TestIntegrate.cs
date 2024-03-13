using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herfitk.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestIntegrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3214EC279B2D105D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client__3214EC272790489E", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__3214EC27D1EB7E98", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Hire_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Work_Hours = table.Column<int>(type: "int", nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff__3214EC27832438F9", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Herfiy",
                columns: table => new
                {
                    HerfiyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Herfiy__3214EC27C698B292", x => x.HerfiyId);
                    table.ForeignKey(
                        name: "FK_Herfiy_AppUser_User_ID",
                        column: x => x.User_ID,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client_Herify",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Client_Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Herify_Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client_ID = table.Column<int>(type: "int", nullable: true),
                    Herify_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client_H__3214EC27824A65FA", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Client_He__Clien__4CA06362",
                        column: x => x.Client_ID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Client_He__Herif__4D94879B",
                        column: x => x.Herify_ID,
                        principalTable: "Herfiy",
                        principalColumn: "HerfiyId");
                });

            migrationBuilder.CreateTable(
                name: "Herify_Category",
                columns: table => new
                {
                    Herify_ID = table.Column<int>(type: "int", nullable: true),
                    Category_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Herify_Ca__Categ__49C3F6B7",
                        column: x => x.Category_ID,
                        principalTable: "Category",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Herify_Ca__Herif__48CFD27E",
                        column: x => x.Herify_ID,
                        principalTable: "Herfiy",
                        principalColumn: "HerfiyId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Payment_term = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Herify_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__3214EC2751EE6894", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Payment__Herify___46E78A0C",
                        column: x => x.Herify_ID,
                        principalTable: "Herfiy",
                        principalColumn: "HerfiyId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Herify_Client_ID",
                table: "Client_Herify",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Herify_Herify_ID",
                table: "Client_Herify",
                column: "Herify_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Herfiy_User_ID",
                table: "Herfiy",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Herify_Category_Category_ID",
                table: "Herify_Category",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Herify_Category_Herify_ID",
                table: "Herify_Category",
                column: "Herify_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Herify_ID",
                table: "Payment",
                column: "Herify_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client_Herify");

            migrationBuilder.DropTable(
                name: "Herify_Category");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Herfiy");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}
