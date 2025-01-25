using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    TaxDepartment = table.Column<string>(type: "varchar(20)", nullable: false),
                    TaxNumber = table.Column<string>(type: "varchar(11)", nullable: false),
                    City = table.Column<string>(type: "varchar(20)", nullable: false),
                    Town = table.Column<string>(type: "varchar(50)", nullable: false),
                    FullAddress = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
