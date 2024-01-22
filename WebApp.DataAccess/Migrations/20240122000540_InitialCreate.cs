using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchParameters",
                columns: table => new
                {
                    SearchParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fieldname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datatype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constraint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    MinLimit = table.Column<int>(type: "int", nullable: true),
                    MaxLimit = table.Column<int>(type: "int", nullable: true),
                    MaskPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchParameters", x => x.SearchParameterId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DOJ = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MgrId = table.Column<int>(type: "int", nullable: true),
                    Seniority = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    EmpCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmpCode",
                table: "Users",
                column: "EmpCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchParameters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
