using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductWebApplication.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("b1fc43ab-c2a9-4e98-8ff0-0953740e1bee"), "Zszywacz biurowy", 35.15m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("bd33dd6d-2ec6-4824-b8f3-3f1395ba51df"), "Gumka do mazania", 3.06m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
