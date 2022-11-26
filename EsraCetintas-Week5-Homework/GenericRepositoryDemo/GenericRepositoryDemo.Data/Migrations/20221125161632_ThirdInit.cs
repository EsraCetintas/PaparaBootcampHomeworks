using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericRepositoryDemo.Data.Migrations
{
    public partial class ThirdInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }
    }
}
