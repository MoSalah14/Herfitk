using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herfitk.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    National_ID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Personal_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalID_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3214EC272A074D8C", x => x.ID);
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
                    table.ForeignKey(
                        name: "FK__Client__User_ID__3F466844",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Herfiy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Herfiy__3214EC27C698B292", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Herfiy__User_ID__4222D4EF",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "ID");
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
                    table.ForeignKey(
                        name: "FK__Role__User_ID__398D8EEE",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "ID");
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
                    table.ForeignKey(
                        name: "FK__Staff__User_ID__3C69FB99",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "ID");
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
                        principalColumn: "ID");
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
                        principalColumn: "ID");
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
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_User_ID",
                table: "Client",
                column: "User_ID");

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
                column: "User_ID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Role_User_ID",
                table: "Role",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_User_ID",
                table: "Staff",
                column: "User_ID");
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
                name: "User");
        }
    }
}
